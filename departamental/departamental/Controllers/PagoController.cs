using System.Web.Http;
using departamental.Models;
using departamental.Services;

namespace departamental.Controllers
{
    [RoutePrefix("api/pagos")]
    public class PagoController : ApiController
    {
        private readonly PagoService _service = new PagoService();

        [HttpPost, Route("{ticketId:int}")]
        public IHttpActionResult RegistrarPago(int ticketId, [FromBody] Pago pago)
            => Ok(_service.RegistrarPago(ticketId, pago));

        [HttpGet, Route("ticket/{ticketId:int}")]
        public IHttpActionResult ListarPagos(int ticketId)
            => Ok(_service.ListarPagosPorTicket(ticketId));
    }
}
