using System.Web.Http;
using departamental.Models;
using departamental.Services;

namespace departamental.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketController : ApiController
    {
        private readonly TicketService _service = new TicketService();

        [HttpPost, Route("")]
        public IHttpActionResult Crear([FromBody] Ticket ticket)
            => Ok(_service.CrearTicket(ticket));

        [HttpGet, Route("")]
        public IHttpActionResult Listar()
            => Ok(_service.ListarTickets());

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Obtener(int id)
            => Ok(_service.ObtenerTicket(id));
    }
}
