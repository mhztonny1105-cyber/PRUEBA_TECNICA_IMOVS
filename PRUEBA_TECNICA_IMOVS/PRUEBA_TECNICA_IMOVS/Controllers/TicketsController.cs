using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly ITicketService _ticketService;

        public TicketsController()
        {
            _ticketService = new TicketService();
        }

        [HttpGet]
        [Route("", Name = "GetAllTickets")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var tickets = _ticketService.GetAllTickets();
                return Ok(tickets);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(new System.Exception("Ocurrió un error al recuperar los tickets."));
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetTicketById")]
        public IHttpActionResult GetById(long id)
        {
            try
            {
                var ticket = _ticketService.GetTicketById(id);
                if (ticket == null) return NotFound();
                return Ok(ticket);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(new System.Exception("Error al consultar el ticket."));
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(CrearTicketDto ticketDataTransferObject)
        {
            if (ticketDataTransferObject == null) return BadRequest("Los datos del ticket son obligatorios.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var ticket = _ticketService.CrearTicket(ticketDataTransferObject);
                return CreatedAtRoute("GetTicketById", new { id = ticket.TicketId }, ticket);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(new System.Exception("Error al crear el ticket. Verifique los datos de entrada."));
            }
        }

        [HttpGet]
        [Route("{id}/pagos")]
        public IHttpActionResult GetHistorial(long id)
        {
            try
            {
                var ticket = _ticketService.GetTicketById(id);
                if (ticket == null) return NotFound();

                var historial = _ticketService.GetHistorialPagos(id);
                return Ok(historial);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(new System.Exception("Error al recuperar el historial de pagos."));
            }
        }
    }
}
