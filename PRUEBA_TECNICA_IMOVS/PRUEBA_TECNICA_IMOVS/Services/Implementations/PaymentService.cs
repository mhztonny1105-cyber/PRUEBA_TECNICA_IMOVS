using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRUEBA_TECNICA_IMOVS.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly Context context;

        public PaymentService(Context context)
        {
            this.context = context;
        }

        public IEnumerable<PaymentResponseDto> GetByTicket(Guid ticketId)
        {
            return context.Payments
                .Where(p => p.TicketId == ticketId)
                .OrderBy(p => p.PaymentDate)
                .Select(p => new PaymentResponseDto
                {
                    Id = p.Id,
                    Folio = p.Folio,
                    PaymentNumber = p.PaymentNumber,
                    Amount = p.Amount,
                    CreatedAt = p.PaymentDate
                })
                .ToList();
        }

        public PaymentResponseDto GetById(Guid id)
        {
            var payment = context.Payments.Find(id);

            if (payment == null)
                throw new KeyNotFoundException("Payment not found");

            return new PaymentResponseDto
            {
                Id = payment.Id,
                Folio = payment.Folio,
                PaymentNumber = payment.PaymentNumber,
                Amount = payment.Amount,
                CreatedAt = payment.PaymentDate
            };
        }

        public void Create(PaymentCreateDto dto)
        {
            var ticket = context.Tickets.Find(dto.TicketId);
            if (ticket == null)
                throw new KeyNotFoundException("Ticket not found");

            var nextPaymentNumber = context.Payments
                .Count(p => p.TicketId == dto.TicketId) + 1;

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                TicketId = dto.TicketId,
                PaymentNumber = nextPaymentNumber,
                Folio = $"PAY-{DateTime.UtcNow:yyyyMMddHHmmss}",
                Amount = dto.Amount,
                PaymentDate = DateTime.UtcNow
            };

            context.Payments.Add(payment);
            context.SaveChanges();
        }
    }
}
