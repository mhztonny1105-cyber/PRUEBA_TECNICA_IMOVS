using System.Web.Http;
using departamental.Models;
using departamental.Services;

namespace departamental.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductoController : ApiController
    {
        private readonly ProductoService _service = new ProductoService();

        [HttpGet, Route("")]
        public IHttpActionResult Get() => Ok(_service.ListarProductos());

        [HttpPost, Route("")]
        public IHttpActionResult Post([FromBody] Producto producto)
            => Ok(_service.CrearProducto(producto));
    }
}
