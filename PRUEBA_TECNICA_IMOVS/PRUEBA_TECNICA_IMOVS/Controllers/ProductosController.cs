using System.Linq;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Controllers {
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController {
        private readonly Context _context = new Context();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll() {
            return Ok(_context.Productos.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) {
            var producto = _context.Productos.Find(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Producto producto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Productos.Add(producto);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, producto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Update(int id, Producto producto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _context.Productos.Find(id);
            if (existing == null)
                return NotFound();

            existing.Nombre = producto.Nombre;
            existing.Precio = producto.Precio;
            existing.Activo = producto.Activo;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id) {
            var producto = _context.Productos.Find(id);
            if (producto == null)
                return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
