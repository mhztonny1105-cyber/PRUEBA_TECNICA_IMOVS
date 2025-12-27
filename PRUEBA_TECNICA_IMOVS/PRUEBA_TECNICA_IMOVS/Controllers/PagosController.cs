using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Services;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/pagos")]
    public class PagosController : ApiController
    {
        private readonly ITicketService _ticketService;

        public PagosController()
        {
            _ticketService = new TicketService();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult RegistrarPago(RegistrarPagoDto pagoDataTransferObject)
        {
            if (pagoDataTransferObject == null) return BadRequest("La información del pago es requerida.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var pago = _ticketService.RegistrarPago(pagoDataTransferObject);
                if (pago == null)
                {
                    return BadRequest("No se pudo registrar el pago. Verifique que el ticket exista y que aún tenga saldo pendiente.");
                }
                return Ok(pago);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(new System.Exception("Error interno al procesar el pago."));
            }
        }
    }
}
