using System;
using System.Data.Entity;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Data;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Services
{
     public class TicketService
    {
        private readonly AppDbContext _db;
        public TicketService(AppDbContext db) => _db = db;

        public decimal CalcularTotal(int ticketId)
        {
            return _db.TicketDetalles
                .Where(d => d.TicketId == ticketId)
                .Select(d => d.Subtotal)
                .DefaultIfEmpty(0m)
                .Sum();
        }

        public decimal MontoPagado(int ticketId)
        {
            return _db.Pagos
                .Where(p => p.TicketId == ticketId)
                .Select(p => p.Monto)
                .DefaultIfEmpty(0m)
                .Sum();
        }

        public decimal Pendiente(int ticketId)
        {
            var total = _db.Tickets.Where(t => t.Id == ticketId).Select(t => t.Total).FirstOrDefault();
            return Math.Max(0m, total - MontoPagado(ticketId));
        }

        public Pago RegistrarPago(int ticketId, decimal monto, string folio = null)
        {
            var ticket = _db.Tickets.Include(t => t.Pagos).FirstOrDefault(t => t.Id == ticketId);
            if (ticket == null) throw new InvalidOperationException("Ticket no encontrado.");

            var pendiente = Pendiente(ticketId);
            if (monto <= 0) throw new InvalidOperationException("Monto inválido.");
            if (monto > pendiente) throw new InvalidOperationException("El monto excede el saldo pendiente.");

            var numeroPago = (ticket.Pagos?.Count ?? 0) + 1;
            var pago = new Pago
            {
                TicketId = ticketId,
                NumeroPago = numeroPago,
                Folio = string.IsNullOrWhiteSpace(folio) ? GenerarFolioPago() : folio.Trim(),
                FechaPago = DateTime.Now,
                Monto = monto
            };

            _db.Pagos.Add(pago);
            _db.SaveChanges();

            var nuevoPendiente = Pendiente(ticketId);
            if (nuevoPendiente == 0 && ticket.Estatus != "Pagado")
            {
                ticket.Estatus = "Pagado";
                ticket.FechaLiquidacion = DateTime.Now;
                _db.SaveChanges();
            }

            return pago;
        }

        public static string GenerarFolioTicket()
            => $"T-{DateTime.UtcNow:yyyyMMddHHmmssfff}-{Guid.NewGuid().ToString("N").Substring(0,6)}";

        public static string GenerarFolioPago()
            => $"P-{DateTime.UtcNow:yyyyMMddHHmmssfff}-{Guid.NewGuid().ToString("N").Substring(0,6)}";
    }
}