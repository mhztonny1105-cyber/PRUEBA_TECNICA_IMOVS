using System;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services;
using System.Collections.Generic;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly ITicketService _service = new TicketService();

        [HttpPost]
        [Route("")]
        public IHttpActionResult CrearTicket([FromBody] TicketRequest request)
        {
            try
            {
                var ticket = new Ticket { Folio = "TICK-" + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() };
                _service.CrearTicket(ticket, request.Detalles);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("{id}/pagos")]
        public IHttpActionResult RegistrarPago(int id, [FromBody] decimal monto)
        {
            try
            {
                _service.RegistrarPago(id, monto);
                var pendiente = _service.CalcularMontoPendiente(id);
                return Ok(new { mensaje = "Pago registrado", saldo_pendiente = pendiente });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/pagos")]
        public IHttpActionResult GetHistorial(int id)
        {
            var historial = _service.ObtenerHistorialPagos(id);
            return Ok(historial);
        }
    }

    public class TicketRequest
    {
        public List<TicketDetalle> Detalles { get; set; }
    }
}