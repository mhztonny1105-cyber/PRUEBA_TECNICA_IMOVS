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
    public class ProductosController : ApiController
    {
        private readonly Context _context = new Context();

        // get productos
        [HttpGet]
        public IHttpActionResult GetProductos()
        {
            try
            {
                var productos = _context.Productos
                    .Where(p => p.Estatus && p.StockDisponible > 0)
                    .ToList();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // obetner por id
        [HttpGet]
        public IHttpActionResult GetProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // insert product
        [HttpPost]
        public IHttpActionResult PostProducto([FromBody] Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validaciones adicionales
                if (producto.PrecioUnitario < 0)
                {
                    return BadRequest("El precio unitario no puede ser negativo.");
                }

                if (producto.StockDisponible < 0)
                {
                    return BadRequest("El stock disponible no puede ser negativo.");
                }

                _context.Productos.Add(producto);
                _context.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // actualizar producto
        [HttpPut]
        public IHttpActionResult PutProducto(int id, [FromBody] Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != producto.Id)
                {
                    return BadRequest("El ID del producto no coincide con el ID de la URL.");
                }

                var productoExistente = _context.Productos.Find(id);
                if (productoExistente == null)
                {
                    return NotFound();
                }

                // Actualizar propiedades
                productoExistente.Nombre = producto.Nombre;
                productoExistente.PrecioUnitario = producto.PrecioUnitario;
                productoExistente.StockDisponible = producto.StockDisponible;
                productoExistente.Estatus = producto.Estatus;

                _context.Entry(productoExistente).State = EntityState.Modified;
                _context.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE producto
        [HttpDelete]
        public IHttpActionResult DeleteProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);
                if (producto == null)
                {
                    return NotFound();
                }

                _context.Productos.Remove(producto);
                _context.SaveChanges();

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // agregar stock
        [HttpPut]
        [Route("api/Productos/{id}/agregarstock")]
        public IHttpActionResult AgregarStock(int id, [FromBody] int cantidad)
        {
            try
            {
                if (cantidad <= 0)
                {
                    return BadRequest("La cantidad debe ser mayor que cero.");
                }

                var producto = _context.Productos.Find(id);
                if (producto == null)
                {
                    return NotFound();
                }

                producto.StockDisponible += cantidad;
                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(producto);
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