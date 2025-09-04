using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private PagosContext db = new PagosContext();

        // GET: api/productos
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetProductos()
        {
            try
            {
                var productos = await db.Productos
                    .Where(p => p.Activo)
                    .OrderBy(p => p.Nombre)
                    .ToListAsync();

                return Ok(ApiResponse<object>.SuccessResponse(productos, "Productos obtenidos exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/productos/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetProducto(int id)
        {
            try
            {
                var producto = await db.Productos.FindAsync(id);

                if (producto == null || !producto.Activo)
                {
                    return NotFound();
                }

                return Ok(ApiResponse<Producto>.SuccessResponse(producto, "Producto encontrado"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/productos
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostProducto(Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validaciones adicionales
                if (producto.PrecioUnitario <= 0)
                {
                    return BadRequest("El precio debe ser mayor a 0");
                }

                if (producto.Stock < 0)
                {
                    return BadRequest("El stock no puede ser negativo");
                }

                producto.FechaCreacion = DateTime.Now;
                producto.Activo = true;

                db.Productos.Add(producto);
                await db.SaveChangesAsync();

                return Ok(ApiResponse<Producto>.SuccessResponse(producto, "Producto creado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/productos/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutProducto(int id, Producto producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != producto.Id)
                {
                    return BadRequest("El ID no coincide");
                }

                var productoExistente = await db.Productos.FindAsync(id);
                if (productoExistente == null || !productoExistente.Activo)
                {
                    return NotFound();
                }

                // Validaciones
                if (producto.PrecioUnitario <= 0)
                {
                    return BadRequest("El precio debe ser mayor a 0");
                }

                if (producto.Stock < 0)
                {
                    return BadRequest("El stock no puede ser negativo");
                }

                // Actualizar campos
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.PrecioUnitario = producto.PrecioUnitario;
                productoExistente.Stock = producto.Stock;

                await db.SaveChangesAsync();

                return Ok(ApiResponse<Producto>.SuccessResponse(productoExistente, "Producto actualizado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/productos/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteProducto(int id)
        {
            try
            {
                var producto = await db.Productos.FindAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }

                // Eliminación lógica
                producto.Activo = false;
                await db.SaveChangesAsync();

                return Ok(ApiResponse<object>.SuccessResponse(null, "Producto eliminado exitosamente"));
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}