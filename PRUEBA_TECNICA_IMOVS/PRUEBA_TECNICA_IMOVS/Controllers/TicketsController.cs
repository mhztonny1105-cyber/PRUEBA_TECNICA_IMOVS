using System;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Implementations;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Controllers {
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController {
        private readonly ITicketService _ticketService;

        public TicketsController() {
            _ticketService = new TicketService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll() {
            return Ok(_ticketService.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id) {
            var ticket = _ticketService.GetById(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(Ticket ticket) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _ticketService.Create(ticket);
            return Content(HttpStatusCode.Created, created);
        }

        [HttpPost]
        [Route("{id:int}/pagos")]
        public IHttpActionResult AddPago(int id, Pago pago) {
            try {
                _ticketService.AddPago(id, pago);
                return Ok("Pago registrado correctamente");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
