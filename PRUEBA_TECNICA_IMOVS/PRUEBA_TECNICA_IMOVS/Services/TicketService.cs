using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class TicketService
    {
        private readonly Context _db = new Context();
        private static string GenFolio() => $"T-{DateTime.UtcNow:yyyyMMddHHmmss}";

        public IEnumerable<Ticket> GetAll() =>
            _db.Tickets.Include(t => t.Customer)
                       .Include(t => t.Items.Select(i => i.Product))
                       .Include(t => t.Payments)
                       .OrderByDescending(t => t.CreatedAt)
                       .ToList();

        public Ticket GetById(int id) =>
            _db.Tickets.Include(t => t.Customer)
                       .Include(t => t.Items.Select(i => i.Product))
                       .Include(t => t.Payments)
                       .FirstOrDefault(t => t.Id == id);

        public Ticket CreateTicket(CreateTicketDto dto)
        {
            var customer = _db.Customers.Find(dto.CustomerId)
                           ?? throw new InvalidOperationException("Cliente no encontrado.");
            if (dto.Items == null || dto.Items.Count == 0)
                throw new InvalidOperationException("El ticket requiere al menos 1 producto.");

            var ticket = new Ticket
            {
                CustomerId = dto.CustomerId,
                Folio = string.IsNullOrWhiteSpace(dto.Folio) ? GenFolio() : dto.Folio.Trim()
            };

            foreach (var it in dto.Items)
            {
                var prod = _db.Products.Find(it.ProductId);
                if (prod == null || !prod.IsActive) throw new InvalidOperationException($"Producto {it.ProductId} inválido.");

                ticket.Items.Add(new TicketItem
                {
                    ProductId = prod.Id,
                    Quantity = it.Quantity,
                    UnitPrice = prod.UnitPrice
                });
            }

            _db.Tickets.Add(ticket);
            _db.SaveChanges();
            return GetById(ticket.Id);
        }

        public Ticket UpdateBasic(int id, string newFolio, int? newCustomerId)
        {
            var t = _db.Tickets.Find(id) ?? throw new InvalidOperationException("Ticket no encontrado.");
            if (!string.IsNullOrWhiteSpace(newFolio)) t.Folio = newFolio.Trim();
            if (newCustomerId.HasValue)
            {
                if (_db.Customers.Find(newCustomerId.Value) == null) throw new InvalidOperationException("Cliente no válido.");
                t.CustomerId = newCustomerId.Value;
            }
            _db.SaveChanges();
            return GetById(id);
        }

        public bool Delete(int id)
        {
            var t = _db.Tickets.Find(id);
            if (t == null) return false;
            _db.Tickets.Remove(t);
            _db.SaveChanges();
            return true;
        }

        public Payment AddPayment(int ticketId, decimal amount)
        {
            var t = _db.Tickets.Include(x => x.Items).Include(x => x.Payments).FirstOrDefault(x => x.Id == ticketId)
                    ?? throw new InvalidOperationException("Ticket no encontrado.");
            if (t.Status == TicketStatus.Pagado) throw new InvalidOperationException("Ticket ya liquidado.");
            if (amount <= 0) throw new InvalidOperationException("Monto inválido.");

            var total = t.Items.Sum(i => i.UnitPrice * i.Quantity);
            var paid = t.Payments.Sum(p => p.Amount);
            var pending = total - paid;
            if (amount > pending) throw new InvalidOperationException($"El pago excede el pendiente ({pending:N2}).");

            var next = (t.Payments.Any() ? t.Payments.Max(p => p.PaymentNumber) : 0) + 1;
            var pay = new Payment
            {
                TicketId = t.Id,
                PaymentNumber = next,
                Amount = amount,
                Folio = $"P-{t.Folio}-{next}"
            };

            _db.Payments.Add(pay);
            _db.SaveChanges();

            paid += amount;
            if (paid >= total)
            {
                t.Status = TicketStatus.Pagado;
                t.PaidAt = DateTime.UtcNow;
                _db.SaveChanges();
            }
            return pay;
        }

        public IEnumerable<Payment> GetPayments(int ticketId)
        {
            if (!_db.Tickets.Any(t => t.Id == ticketId)) throw new InvalidOperationException("Ticket no encontrado.");
            return _db.Payments.Where(p => p.TicketId == ticketId).OrderByDescending(p => p.PaidAt).ToList();
        }
    }
}
