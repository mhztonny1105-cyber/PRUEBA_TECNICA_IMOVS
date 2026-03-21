using System;
using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class TicketService : ITicketService
    {
        private readonly Context _db = new Context();

        public void CrearTicket(Ticket ticket, List<TicketDetalle> detalles)
        {
            ticket.FechaCreacion = DateTime.Now;
            ticket.Estatus = "Por pagar";
            ticket.Total = detalles.Sum(d => d.Cantidad * d.PrecioUnitario);

            _db.Tickets.Add(ticket);
            _db.SaveChanges();

            foreach (var detalle in detalles)
            {
                detalle.TicketId = ticket.Id;
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
                _db.TicketDetalles.Add(detalle);
            }
            _db.SaveChanges();
        }

        public void RegistrarPago(int ticketId, decimal monto)
        {
            var ticket = _db.Tickets.Find(ticketId);
            if (ticket == null) throw new Exception("El ticket no existe.");

            var ultimoPago = _db.Pagos.Where(p => p.TicketId == ticketId)
                                     .OrderByDescending(p => p.NumeroPago)
                                     .FirstOrDefault();

            var nuevoPago = new Pago
            {
                TicketId = ticketId,
                Monto = monto,
                FechaPago = DateTime.Now,
                NumeroPago = (ultimoPago?.NumeroPago ?? 0) + 1,
                Folio = "PAGO-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper()
            };

            _db.Pagos.Add(nuevoPago);
            _db.SaveChanges();

            ActualizarEstatusTicket(ticketId);
        }

        public decimal CalcularMontoPendiente(int ticketId)
        {
            var ticket = _db.Tickets.Find(ticketId);
            var totalPagado = _db.Pagos.Where(p => p.TicketId == ticketId).Sum(p => (decimal?)p.Monto) ?? 0;

            return ticket.Total - totalPagado;
        }

        public IEnumerable<Pago> ObtenerHistorialPagos(int ticketId) => _db.Pagos.Where(p => p.TicketId == ticketId).OrderByDescending(p => p.FechaPago).ToList();

        private void ActualizarEstatusTicket(int ticketId)
        {
            var ticket = _db.Tickets.Find(ticketId);
            var pendiente = CalcularMontoPendiente(ticketId);

            if (pendiente <= 0)
            {
                ticket.Estatus = "Pagado";
                ticket.FechaLiquidacion = DateTime.Now;
            }
            
            _db.SaveChanges();
        }
    }
}