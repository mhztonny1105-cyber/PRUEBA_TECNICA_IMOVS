using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/pagos")]
    public class PagosController : ApiController
    {
        private readonly AppDbContext _context;

        public PagosController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        [Route("ticket/{ticketId:int}")]
        public IHttpActionResult GetPagosByTicket(int ticketId)
        {
            try
            {
                var ticket = _context.Tickets.Find(ticketId);

                if (ticket == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Ticket no encontrado"));
                }

                var pagos = _context.Pagos
                    .Where(p => p.TicketId == ticketId)
                    .OrderByDescending(p => p.FechaPago)
                    .ToList();

                return Ok(ApiResponse<object>.SuccessResponse(new
                {
                    TicketId = ticketId,
                    TicketFolio = ticket.Folio,
                    MontoTotal = ticket.MontoTotal,
                    MontoPagado = ticket.MontoPagado,
                    MontoPendiente = ticket.MontoPendiente,
                    Estatus = ticket.Estatus,
                    Pagos = pagos
                }));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetPago(int id)
        {
            try
            {
                var pago = _context.Pagos
                    .Include(p => p.Ticket)
                    .FirstOrDefault(p => p.PagoId == id);

                if (pago == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Pago no encontrado"));
                }

                return Ok(ApiResponse<object>.SuccessResponse(pago));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostPago(PagoCreateDto pagoDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ticket = _context.Tickets
                    .Include(t => t.Pagos)
                    .FirstOrDefault(t => t.TicketId == pagoDto.TicketId);

                if (ticket == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Ticket no encontrado"));
                }

                if (ticket.Estatus == "Pagado")
                {
                    return BadRequest("El ticket ya está completamente pagado");
                }

                var montoPendiente = ticket.MontoTotal - ticket.MontoPagado;

                if (pagoDto.Monto > montoPendiente)
                {
                    return BadRequest($"El monto excede el pendiente de pago ({montoPendiente:C})");
                }

                var numeroPago = ticket.Pagos.Any() ? ticket.Pagos.Max(p => p.NumeroPago) + 1 : 1;
                var folio = $"PAG-{DateTime.Now:yyyyMMddHHmmss}-{numeroPago}";

                var pago = new Pago
                {
                    Folio = folio,
                    TicketId = pagoDto.TicketId,
                    NumeroPago = numeroPago,
                    Monto = pagoDto.Monto,
                    FechaPago = DateTime.Now,
                    Observaciones = pagoDto.Observaciones
                };

                _context.Pagos.Add(pago);

                ticket.MontoPagado += pagoDto.Monto;

                if (ticket.MontoPagado >= ticket.MontoTotal)
                {
                    ticket.Estatus = "Pagado";
                    ticket.FechaLiquidacion = DateTime.Now;
                }

                _context.SaveChanges();

                return Created($"api/pagos/{pago.PagoId}",
                    ApiResponse<object>.SuccessResponse(new
                    {
                        pago.PagoId,
                        pago.Folio,
                        pago.NumeroPago,
                        pago.Monto,
                        pago.FechaPago,
                        TicketEstatus = ticket.Estatus,
                        MontoPendiente = ticket.MontoPendiente
                    }, "Pago registrado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeletePago(int id)
        {
            try
            {
                var pago = _context.Pagos.Find(id);

                if (pago == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Pago no encontrado"));
                }

                var ticket = _context.Tickets.Find(pago.TicketId);

                ticket.MontoPagado -= pago.Monto;

                if (ticket.MontoPagado < ticket.MontoTotal)
                {
                    ticket.Estatus = "PorPagar";
                    ticket.FechaLiquidacion = null;
                }

                _context.Pagos.Remove(pago);
                _context.SaveChanges();

                return Ok(ApiResponse<object>.SuccessResponse(null,
                    "Pago eliminado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class PagoCreateDto
    {
        public int TicketId { get; set; }
        public decimal Monto { get; set; }
        public string Observaciones { get; set; }
    }
}