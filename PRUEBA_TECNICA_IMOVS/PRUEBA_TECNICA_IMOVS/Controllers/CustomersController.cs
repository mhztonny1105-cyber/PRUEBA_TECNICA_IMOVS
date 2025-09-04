using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly CustomerService _svc = new CustomerService();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll() => Ok(_svc.GetAll());

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var c = _svc.GetById(id);
            if (c == null) return Content(HttpStatusCode.NotFound, "No encontrado");
            return Ok(c);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post(Customer c)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = _svc.Create(c);
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Put(int id, Customer c)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var res = _svc.Update(id, c);
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
