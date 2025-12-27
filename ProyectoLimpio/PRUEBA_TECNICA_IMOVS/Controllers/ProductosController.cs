using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private readonly IProductoService _productoService;

        public ProductosController()
        {
            _productoService = new ProductoService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_productoService.GetAll());
            }
            catch (System.Exception)
            {
                return InternalServerError(new System.Exception("Error al recuperar el catálogo de productos."));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(long id)
        {
            try
            {
                var producto = _productoService.GetById(id);
                if (producto == null) return NotFound();

                return Ok(producto);
            }
            catch (System.Exception)
            {
                return InternalServerError(new System.Exception("Error al consultar el detalle del producto."));
            }
        }
    }
}
