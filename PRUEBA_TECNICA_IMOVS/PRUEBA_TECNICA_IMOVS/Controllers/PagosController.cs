using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/pagos")]
    public class PagosController : ApiController
    {
        private PagosContext db = new PagosContext();

        // GET: api/pagos
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetPagos()
        {
            try
            {
                var pagos = await db.Pagos
                    .Include(p => p.Ticket)
                    .OrderByDescending(p => p.FechaPago)
                    .Select(p => new
                    {
                        p.Id,
                        p.Folio,
                        p.TicketId,
                        FolioTicket = p.Ticket.Folio,
                        Cliente = p.Ticket.Cliente,
                        p.NumeroPago,
                        p.Monto,
                        p.FechaPago,
                        p.Comentarios
                    })
                    .ToListAsync();

                return Ok(ApiResponse<object>.SuccessResponse(pagos, "Pagos obtenidos exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/pagos/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetPago(int id)
        {
            try
            {
                var pago = await db.Pagos
                    .Include(p => p.Ticket)
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        p.Id,
                        p.Folio,
                        p.TicketId,
                        FolioTicket = p.Ticket.Folio,
                        Cliente = p.Ticket.Cliente,
                        MontoTotalTicket = p.Ticket.MontoTotal,
                        MontoPagadoTicket = p.Ticket.MontoPagado,
                        p.NumeroPago,
                        p.Monto,
                        p.FechaPago,
                        p.Comentarios
                    })
                    .FirstOrDefaultAsync();

                if (pago == null)
                {
                    return NotFound();
                }

                return Ok(ApiResponse<object>.SuccessResponse(pago, "Pago encontrado"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/pagos/ticket/5
        [HttpGet]
        [Route("ticket/{ticketId:int}")]
        public async Task<IHttpActionResult> GetPagosByTicket(int ticketId)
        {
            try
            {
                var ticket = await db.Tickets.FindAsync(ticketId);
                if (ticket == null)
                {
                    return NotFound();
                }

                var pagos = await db.Pagos
                    .Where(p => p.TicketId == ticketId)
                    .OrderByDescending(p => p.FechaPago)
                    .Select(p => new
                    {
                        p.Id,
                        p.Folio,
                        p.NumeroPago,
                        p.Monto,
                        p.FechaPago,
                        p.Comentarios
                    })
                    .ToListAsync();

                var response = new
                {
                    Ticket = new
                    {
                        ticket.Id,
                        ticket.Folio,
                        ticket.Cliente,
                        ticket.MontoTotal,
                        ticket.MontoPagado,
                        MontoPendiente = ticket.MontoTotal - ticket.MontoPagado,
                        ticket.Estatus
                    },
                    Pagos = pagos
                };

                return Ok(ApiResponse<object>.SuccessResponse(response, "Historial de pagos obtenido exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/pagos
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostPago(PagoCreateDto pagoDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verificar que el ticket existe
                var ticket = await db.Tickets.FindAsync(pagoDto.TicketId);
                if (ticket == null)
                {
                    return BadRequest("El ticket especificado no existe");
                }

                // Verificar que el ticket no esté completamente pagado
                if (ticket.Estatus == "Pagado")
                {
                    return BadRequest("El ticket ya está completamente pagado");
                }

                // Calcular monto pendiente actual
                decimal montoPendiente = ticket.MontoTotal - ticket.MontoPagado;

                // Validar que el monto del pago no exceda el pendiente
                if (pagoDto.Monto > montoPendiente)
                {
                    return BadRequest($"El monto del pago (${pagoDto.Monto}) no puede ser mayor al monto pendiente (${montoPendiente})");
                }

                if (pagoDto.Monto <= 0)
                {
                    return BadRequest("El monto del pago debe ser mayor a 0");
                }

                // Generar folio de pago único
                string folioPago = GenerarFolioPago();

                // Obtener el siguiente número de pago para este ticket
                int siguienteNumeroPago = await db.Pagos
                    .Where(p => p.TicketId == pagoDto.TicketId)
                    .MaxAsync(p => (int?)p.NumeroPago) ?? 0;
                siguienteNumeroPago++;

                // Crear el pago
                var pago = new Pago
                {
                    Folio = folioPago,
                    TicketId = pagoDto.TicketId,
                    NumeroPago = siguienteNumeroPago,
                    Monto = pagoDto.Monto,
                    FechaPago = DateTime.Now,
                    Comentarios = pagoDto.Comentarios
                };

                db.Pagos.Add(pago);

                // Actualizar el monto pagado del ticket
                ticket.MontoPagado += pagoDto.Monto;

                // Verificar si el ticket se liquidó completamente
                if (ticket.MontoPagado >= ticket.MontoTotal)
                {
                    ticket.Estatus = "Pagado";
                    ticket.FechaLiquidacion = DateTime.Now;
                }

                await db.SaveChangesAsync();

                var response = new
                {
                    pago.Id,
                    pago.Folio,
                    pago.NumeroPago,
                    pago.Monto,
                    pago.FechaPago,
                    Ticket = new
                    {
                        ticket.Id,
                        ticket.Folio,
                        ticket.MontoTotal,
                        ticket.MontoPagado,
                        MontoPendiente = ticket.MontoTotal - ticket.MontoPagado,
                        ticket.Estatus,
                        ticket.FechaLiquidacion
                    }
                };

                return Ok(ApiResponse<object>.SuccessResponse(response, "Pago registrado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/pagos/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutPago(int id, PagoUpdateDto pagoDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var pago = await db.Pagos.Include(p => p.Ticket).FirstOrDefaultAsync(p => p.Id == id);
                if (pago == null)
                {
                    return NotFound();
                }

                // Solo permitir editar comentarios
                pago.Comentarios = pagoDto.Comentarios;

                await db.SaveChangesAsync();

                return Ok(ApiResponse<object>.SuccessResponse(pago, "Pago actualizado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/pagos/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeletePago(int id)
        {
            try
            {
                var pago = await db.Pagos.Include(p => p.Ticket).FirstOrDefaultAsync(p => p.Id == id);
                if (pago == null)
                {
                    return NotFound();
                }

                var ticket = pago.Ticket;

                // Revertir el monto pagado en el ticket
                ticket.MontoPagado -= pago.Monto;

                // Actualizar estatus del ticket
                if (ticket.MontoPagado < ticket.MontoTotal)
                {
                    ticket.Estatus = "Por Pagar";
                    ticket.FechaLiquidacion = null;
                }

                // Eliminar el pago
                db.Pagos.Remove(pago);

                await db.SaveChangesAsync();

                return Ok(ApiResponse<object>.SuccessResponse(null, "Pago eliminado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private string GenerarFolioPago()
        {
            return "PAG-" + DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(1000, 9999);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    // DTOs para crear y actualizar pagos
    public class PagoCreateDto
    {
        public int TicketId { get; set; }
        public decimal Monto { get; set; }
        public string Comentarios { get; set; }
    }

    public class PagoUpdateDto
    {
        public string Comentarios { get; set; }
    }
}