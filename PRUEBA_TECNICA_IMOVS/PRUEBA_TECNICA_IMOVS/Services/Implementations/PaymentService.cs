



using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Linq;

namespace PRUEBA_TECNICA_IMOVS.Services.Implementations
{


    public class PaymentService : IPaymentService
    {
        private readonly Context context;

        public PaymentService(Context context)
        {
            context = context;
        }

        public Payment Register(PaymentCreateDto dto)
        {
            var ticket = context.Tickets
                .Include("Payments")
                .FirstOrDefault(t => t.Id == dto.TicketId);

            if (ticket == null)
                throw new Exception("Ticket no encontrado");

            if (ticket.Status == TicketStatus.Pagado)
                throw new Exception("El ticket ya está liquidado");

            if (dto.Amount > ticket.PendingAmount)
                throw new Exception("El monto excede el saldo pendiente");

            var paymentNumber = ticket.Payments.Count + 1;

            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                TicketId = ticket.Id,
                PaymentNumber = paymentNumber,
                Folio = $"PAY-{DateTime.Now:yyyyMMddHHmmss}",
                Amount = dto.Amount,
                PaymentDate = DateTime.Now
            };

            ticket.PendingAmount -= dto.Amount;

            if (ticket.PendingAmount == 0)
            {
                ticket.Status = TicketStatus.Pagado;
                ticket.PaidDate = DateTime.Now;
            }

            context.Payments.Add(payment);
            context.SaveChanges();

            return payment;
        }

    
    }



}