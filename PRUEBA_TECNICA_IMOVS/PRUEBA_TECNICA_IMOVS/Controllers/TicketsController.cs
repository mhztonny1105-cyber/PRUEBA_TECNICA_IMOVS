using System;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly TicketService _svc = new TicketService();

        [HttpGet, Route("")]
        public IHttpActionResult GetAll() => Ok(_svc.GetAll());

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var t = _svc.GetById(id);
            if (t == null) return Content(HttpStatusCode.NotFound, "No encontrado");
            return Ok(t);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(CreateTicketDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try { var t = _svc.CreateTicket(dto); return Content(HttpStatusCode.Created, t); }
            catch (Exception ex) { return Content(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult UpdateBasic(int id, [FromBody] dynamic body)
        {
            try
            {
                string folio = body?.Folio;
                int? customerId = body?.CustomerId;
                var updated = _svc.UpdateBasic(id, folio, customerId);
                return Ok(updated);
            }
            catch (Exception ex) { return Content(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var ok = _svc.Delete(id);
            if (!ok) return Content(HttpStatusCode.NotFound, "No encontrado");
            return Ok(true);
        }

        [HttpPost, Route("{id:int}/payments")]
        public IHttpActionResult AddPayment(int id, PaymentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try { var p = _svc.AddPayment(id, dto.Amount); return Content(HttpStatusCode.Created, p); }
            catch (Exception ex) { return Content(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpGet, Route("{id:int}/payments")]
        public IHttpActionResult GetPayments(int id)
        {
            try { var list = _svc.GetPayments(id); return Ok(list); }
            catch (Exception ex) { return Content(HttpStatusCode.BadRequest, ex.Message); }
        }
    }
}
