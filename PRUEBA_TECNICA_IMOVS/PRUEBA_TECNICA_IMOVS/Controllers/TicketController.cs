using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class TicketController
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet, Route("api/tickets")]
        public IHttpActionResult GetAll()
        {
            var tickets = _service.GetAll();
            return Ok(tickets);
        }

        [HttpGet, Route("api/tickets/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var ticket = _service.GetById(id);
            return Ok(ticket);
        }

        [HttpPost, Route("api/tickets")]
        public IHttpActionResult Create(CreateTicketDto createTicketDto)
        {
            var ticket = _service.Create(createTicketDto);
            return Ok(ticket);
        }

        [HttpPut, Route("api/tickets/{id:int}")]
        public IHttpActionResult Update(int id, UpdateTicketDto updateTicketDto)
        {
            var updatedTicket = _service.Update(id, updateTicketDto);
            return Ok(updatedTicket);
        }

        [HttpDelete, Route("api/tickets/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Ticket deleted successfully");
        }
    }
}