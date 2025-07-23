using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class CotizacionesController : ApiController
    {
        private readonly Context _context = new Context();

        // GET: api/Cotizaciones
        [HttpGet]
        public IHttpActionResult GetCotizaciones()
        {
            try
            {
                var cotizaciones = _context.Cotizaciones
                    .Include(c => c.Detalles)
                    .ToList();
                return Ok(cotizaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Cotizaciones/ProductosDisponibles
        [HttpGet]
        [Route("api/Cotizaciones/ProductosDisponibles")]
        public IHttpActionResult GetProductosDisponibles()
        {
            try
            {
                // Solo productos activos y con stock > 0
                var productos = _context.Productos
                    .Where(p => p.Estatus && p.StockDisponible > 0)
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.PrecioUnitario,
                        p.StockDisponible
                    })
                    .ToList();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Cotizaciones
        [HttpPost]
        public IHttpActionResult PostCotizacion([FromBody] Cotizacion cotizacion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validar que haya detalles
                if (cotizacion.Detalles == null || !cotizacion.Detalles.Any())
                {
                    return BadRequest("La cotización debe tener al menos un producto.");
                }

                // Validar stock y calcular totales
                decimal totalCalculado = 0;
                foreach (var detalle in cotizacion.Detalles)
                {
                    var producto = _context.Productos.Find(detalle.ProductoId);
                    if (producto == null)
                    {
                        return BadRequest($"Producto con ID {detalle.ProductoId} no encontrado.");
                    }

                    if (detalle.UnidadesCotizadas > producto.StockDisponible)
                    {
                        return BadRequest($"No hay suficiente stock para {producto.Nombre}. Disponible: {producto.StockDisponible}");
                    }

                    detalle.PrecioTotal = detalle.UnidadesCotizadas * producto.PrecioUnitario;
                    totalCalculado += detalle.PrecioTotal;
                }

                // Calcular totales
                cotizacion.TotalCotizacion = totalCalculado;
                cotizacion.IVA = totalCalculado * 0.16m; // IVA del 16%
                cotizacion.FechaCotizacion = DateTime.Now;
                cotizacion.EstadoVenta = true; // Confirmada como venta

                // Guardar cotización
                _context.Cotizaciones.Add(cotizacion);
                _context.SaveChanges();

                // Reducir stock de productos
                foreach (var detalle in cotizacion.Detalles)
                {
                    var producto = _context.Productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        producto.StockDisponible -= detalle.UnidadesCotizadas;
                    }
                }

                _context.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = cotizacion.Id }, cotizacion);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Cotizaciones/5/ConfirmarVenta
        [HttpPut]
        [Route("api/Cotizaciones/{id}/ConfirmarVenta")]
        public IHttpActionResult ConfirmarVenta(int id)
        {
            try
            {
                var cotizacion = _context.Cotizaciones
                    .Include(c => c.Detalles)
                    .FirstOrDefault(c => c.Id == id);

                if (cotizacion == null)
                {
                    return NotFound();
                }

                if (cotizacion.EstadoVenta)
                {
                    return BadRequest("La cotización ya está confirmada como venta.");
                }

                // Verificar stock disponible
                foreach (var detalle in cotizacion.Detalles)
                {
                    var producto = _context.Productos.Find(detalle.ProductoId);
                    if (producto == null)
                    {
                        return BadRequest($"Producto no encontrado: {detalle.ProductoId}");
                    }

                    if (detalle.UnidadesCotizadas > producto.StockDisponible)
                    {
                        return BadRequest($"No hay suficiente stock para {producto.Nombre}. Disponible: {producto.StockDisponible}");
                    }
                }

                // Reducir stock y confirmar venta
                foreach (var detalle in cotizacion.Detalles)
                {
                    var producto = _context.Productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        producto.StockDisponible -= detalle.UnidadesCotizadas;
                    }
                }

                cotizacion.EstadoVenta = true;
                cotizacion.FechaCotizacion = DateTime.Now; // Actualizar fecha
                _context.SaveChanges();

                return Ok(cotizacion);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Liberar recursos
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}