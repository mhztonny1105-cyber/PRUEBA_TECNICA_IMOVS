using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Responses;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Net;
using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]

        public IHttpActionResult GetAll()
        {
            var tickets = _service.GetAll();
            return Ok(ApiResponse<object>.Ok(tickets));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IHttpActionResult GetById(Guid id)
        {
            var ticket = _service.GetById(id); // si no existe, KeyNotFoundException -> filtro global
            return Ok(ApiResponse<object>.Ok(ticket));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] TicketCreateDto dto)
        {
            if (dto == null)
                return BadRequest("El body es obligatorio");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ticket = _service.Create(dto);
            return Content(HttpStatusCode.Created, ApiResponse<object>.Ok(ticket, "Ticket creado"));
        }
    }
}
