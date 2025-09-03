using System.Linq;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Data;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controller
{
    [RoutePrefix("api/productos")]
    public class ProductosController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
            => Ok(ApiResponse<object>.Success(_db.Productos.ToList()));

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var item = _db.Productos.Find(id);
            if (item == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            return Ok(ApiResponse<object>.Success(item));
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(Producto model)
        {
            if (!ModelState.IsValid) return BadRequest("Modelo inválido");
            _db.Productos.Add(model);
            _db.SaveChanges();
            return Created($"api/productos/{model.Id}", ApiResponse<object>.Success(model, "Creado"));
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Update(int id, Producto model)
        {
            var item = _db.Productos.Find(id);
            if (item == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            if (!ModelState.IsValid) return BadRequest("Modelo inválido");

            item.Nombre = model.Nombre;
            item.PrecioUnitario = model.PrecioUnitario;
            _db.SaveChanges();
            return Ok(ApiResponse<object>.Success(item, "Actualizado"));
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var item = _db.Productos.Find(id);
            if (item == null) return Content(HttpStatusCode.NotFound, ApiResponse<object>.Fail("No encontrado"));
            _db.Productos.Remove(item);
            _db.SaveChanges();
            return Ok(ApiResponse<object>.Success(null, "Eliminado"));
        }
    }
}