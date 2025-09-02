using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class TicketDetailController
    {
        private readonly ITicketDetailService _service;

        public TicketDetailController(ITicketDetailService service)
        {
            _service = service;
        }

        [HttpGet, Route("api/ticket-details")]
        public IHttpActionResult GetAll()
        {
            var ticketDetails = _service.GetAll();
            return Ok(ticketDetails);
        }

        [HttpGet, Route("api/ticket-details/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var ticketDetail = _service.GetById(id);
            return Ok(ticketDetail);
        }

        [HttpPost, Route("api/ticket-details")]
        public IHttpActionResult Create(CreateTicketDetailDto createTicketDetailDto)
        {
            var ticketDetail = _service.Create(createTicketDetailDto);
            return Ok(ticketDetail);
        }

        [HttpPut, Route("api/ticket-details/{id:int}")]
        public IHttpActionResult Update(int id, UpdateTicketDetailDto updateTicketDetailDto)
        {
            var updatedTicketDetail = _service.Update(id, updateTicketDetailDto);
            return Ok(updatedTicketDetail);
        }

        [HttpDelete, Route("api/ticket-details/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Ticket Detail deleted successfully");
        }
    }
}