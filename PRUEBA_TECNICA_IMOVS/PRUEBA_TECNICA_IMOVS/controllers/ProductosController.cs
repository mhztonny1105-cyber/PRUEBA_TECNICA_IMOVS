using System.Linq;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private readonly Context _db = new Context();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_db.Productos.ToList());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Producto producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Productos.Add(producto);
            _db.SaveChanges();
            return Ok(producto);
        }
    }
}