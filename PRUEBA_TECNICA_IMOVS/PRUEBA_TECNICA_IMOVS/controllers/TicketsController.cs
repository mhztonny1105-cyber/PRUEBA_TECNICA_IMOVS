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
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly AppDbContext _context;

        public TicketsController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTickets()
        {
            try
            {
                var tickets = _context.Tickets
                    .Include(t => t.Detalles.Select(d => d.Producto))
                    .Include(t => t.Pagos)
                    .OrderByDescending(t => t.FechaCreacion)
                    .ToList()
                    .Select(t => new
                    {
                        t.TicketId,
                        t.Folio,
                        t.FechaCreacion,
                        t.FechaLiquidacion,
                        t.MontoTotal,
                        t.MontoPagado,
                        MontoPendiente = t.MontoPendiente,
                        t.Estatus,
                        t.Cliente,
                        Detalles = t.Detalles.Select(d => new
                        {
                            d.TicketDetalleId,
                            d.ProductoId,
                            ProductoNombre = d.Producto.Nombre,
                            d.Cantidad,
                            d.PrecioUnitario,
                            Subtotal = d.Subtotal
                        }),
                        CantidadPagos = t.Pagos.Count
                    })
                    .ToList();

                return Ok(ApiResponse<object>.SuccessResponse(tickets));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTicket(int id)
        {
            try
            {
                var ticket = _context.Tickets
                    .Include(t => t.Detalles.Select(d => d.Producto))
                    .Include(t => t.Pagos)
                    .FirstOrDefault(t => t.TicketId == id);

                if (ticket == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Ticket no encontrado"));
                }

                var resultado = new
                {
                    ticket.TicketId,
                    ticket.Folio,
                    ticket.FechaCreacion,
                    ticket.FechaLiquidacion,
                    ticket.MontoTotal,
                    ticket.MontoPagado,
                    MontoPendiente = ticket.MontoPendiente,
                    ticket.Estatus,
                    ticket.Cliente,
                    Detalles = ticket.Detalles.Select(d => new
                    {
                        d.TicketDetalleId,
                        d.ProductoId,
                        ProductoNombre = d.Producto.Nombre,
                        d.Cantidad,
                        d.PrecioUnitario,
                        Subtotal = d.Subtotal
                    }),
                    Pagos = ticket.Pagos.OrderByDescending(p => p.FechaPago).Select(p => new
                    {
                        p.PagoId,
                        p.Folio,
                        p.NumeroPago,
                        p.Monto,
                        p.FechaPago,
                        p.Observaciones
                    })
                };

                return Ok(ApiResponse<object>.SuccessResponse(resultado));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostTicket(TicketCreateDto ticketDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (ticketDto.Detalles == null || !ticketDto.Detalles.Any())
                {
                    return BadRequest("El ticket debe tener al menos un detalle");
                }

                var folio = $"TKT-{DateTime.Now:yyyyMMddHHmmss}";

                var ticket = new Ticket
                {
                    Folio = folio,
                    FechaCreacion = DateTime.Now,
                    Cliente = ticketDto.Cliente,
                    Estatus = "PorPagar"
                };

                decimal montoTotal = 0;

                foreach (var detalleDto in ticketDto.Detalles)
                {
                    var producto = _context.Productos.Find(detalleDto.ProductoId);

                    if (producto == null)
                    {
                        return BadRequest($"Producto con ID {detalleDto.ProductoId} no encontrado");
                    }

                    if (producto.Stock < detalleDto.Cantidad)
                    {
                        return BadRequest($"Stock insuficiente para el producto {producto.Nombre}");
                    }

                    var detalle = new TicketDetalle
                    {
                        ProductoId = detalleDto.ProductoId,
                        Cantidad = detalleDto.Cantidad,
                        PrecioUnitario = producto.PrecioUnitario
                    };

                    montoTotal += detalle.Subtotal;
                    producto.Stock -= detalleDto.Cantidad;

                    ticket.Detalles.Add(detalle);
                }

                ticket.MontoTotal = montoTotal;

                _context.Tickets.Add(ticket);
                _context.SaveChanges();

                return Created($"api/tickets/{ticket.TicketId}",
                    ApiResponse<object>.SuccessResponse(new
                    {
                        ticket.TicketId,
                        ticket.Folio,
                        ticket.FechaCreacion,
                        ticket.MontoTotal,
                        ticket.Estatus,
                        ticket.Cliente
                    }, "Ticket creado exitosamente"));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteTicket(int id)
        {
            try
            {
                var ticket = _context.Tickets
                    .Include(t => t.Pagos)
                    .FirstOrDefault(t => t.TicketId == id);

                if (ticket == null)
                {
                    return Content(HttpStatusCode.NotFound,
                        ApiResponse<object>.ErrorResponse("Ticket no encontrado"));
                }

                if (ticket.Pagos.Any())
                {
                    return BadRequest("No se puede eliminar un ticket con pagos registrados");
                }

                _context.Tickets.Remove(ticket);
                _context.SaveChanges();

                return Ok(ApiResponse<object>.SuccessResponse(null,
                    "Ticket eliminado exitosamente"));
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

    public class TicketCreateDto
    {
        public string Cliente { get; set; }
        public TicketDetalleDto[] Detalles { get; set; }
    }

    public class TicketDetalleDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}