using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Services.Implementations {
    public class TicketService : ITicketService {
        private readonly Context _context;

        public TicketService() {
            _context = new Context();
        }

        public IEnumerable<Ticket> GetAll() {
            return _context.Tickets
                .Include(t => t.Detalles)
                .Include(t => t.Pagos)
                .ToList();
        }

        public Ticket GetById(int id) {
            return _context.Tickets
                .Include(t => t.Detalles)
                .Include(t => t.Pagos)
                .FirstOrDefault(t => t.Id == id);
        }

        public Ticket Create(Ticket ticket) {
            ticket.Estatus = "Por Pagar";
            ticket.FechaCreacion = DateTime.Now;
            ticket.Folio = $"TCK-{DateTime.Now.Ticks}";

            ticket.Total = ticket.Detalles.Sum(d => {
                d.PrecioUnitario = d.PrecioUnitario;
                d.TotalLinea = d.Cantidad * d.PrecioUnitario;
                return d.TotalLinea;
            });

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket;
        }

        public void AddPago(int ticketId, Pago pago) {
            var ticket = _context.Tickets
                .Include(t => t.Pagos)
                .FirstOrDefault(t => t.Id == ticketId);

            if (ticket == null)
                throw new Exception("Ticket no encontrado");

            var totalPagado = ticket.Pagos.Sum(p => p.Monto);
            var restante = ticket.Total - totalPagado;

            if (pago.Monto > restante)
                throw new Exception("El monto excede el saldo pendiente");

            pago.NumeroPago = ticket.Pagos.Count + 1;
            pago.Folio = $"PAG-{DateTime.Now.Ticks}";
            pago.TicketId = ticketId;

            ticket.Pagos.Add(pago);

            totalPagado += pago.Monto;

            if (totalPagado == ticket.Total) {
                ticket.Estatus = "Pagado";
                ticket.FechaLiquidacion = DateTime.Now;
            }

            _context.SaveChanges();
        }
    }
}
