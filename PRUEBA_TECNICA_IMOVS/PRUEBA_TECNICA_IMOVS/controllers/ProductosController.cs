using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private readonly AppDbContext _context;

        public ProductosController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetProductos()
        {
            try
            {
                var productos = _context.Productos
                    .Where(p => p.Activo)
                    .OrderBy(p => p.Nombre)
                    .ToList();

                return Ok(ApiResponse<object>.SuccessResponse(productos));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);

                if (producto == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Producto no encontrado"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(producto));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostProducto(Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Productos.Add(producto);
                _context.SaveChanges();

                return Created($"api/productos/{producto.ProductoId}",
                    ApiResponse<object>.SuccessResponse(producto, "Producto creado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult PutProducto(int id, Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productoExistente = _context.Productos.Find(id);

                if (productoExistente == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Producto no encontrado"));
                }

                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.PrecioUnitario = producto.PrecioUnitario;
                productoExistente.Stock = producto.Stock;
                productoExistente.Activo = producto.Activo;

                _context.SaveChanges();

                return Ok(ApiResponse<object>.SuccessResponse(productoExistente,
                    "Producto actualizado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteProducto(int id)
        {
            try
            {
                var producto = _context.Productos.Find(id);

                if (producto == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Producto no encontrado"));
                }

                producto.Activo = false;
                _context.SaveChanges();

                return Ok(ApiResponse<object>.SuccessResponse(null,
                    "Producto eliminado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

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