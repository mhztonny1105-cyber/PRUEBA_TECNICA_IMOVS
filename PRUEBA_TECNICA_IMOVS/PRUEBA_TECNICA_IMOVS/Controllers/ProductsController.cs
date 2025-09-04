using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly ProductService _svc = new ProductService();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll() => Ok(_svc.GetAll());

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var p = _svc.GetById(id);
            if (p == null) return Content(HttpStatusCode.NotFound, "No encontrado");
            return Ok(p);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post(Product p)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = _svc.Create(p);
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Put(int id, Product p)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var res = _svc.Update(id, p);
            if (res == null) return Content(HttpStatusCode.NotFound, "No encontrado");
            return Ok(res);
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var ok = _svc.Delete(id);
            if (!ok) return Content(HttpStatusCode.NotFound, "No encontrado");
            return Ok(true);
        }
    }
}
