using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PRUEBA_TECNICA_IMOVS.Api.Data.Repositories;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Api.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Api.Services.Contracts;


namespace PRUEBA_TECNICA_IMOVS.Api.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<Ticket> _ticketRepo;
        private readonly IMapper _mapper;


        public PaymentService(IGenericRepository<Payment> paymentRepo, IGenericRepository<Ticket> ticketRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _ticketRepo = ticketRepo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var list = await _paymentRepo.Query()
            .OrderByDescending(p => p.PaidAt)
            .ThenByDescending(p => p.PaymentNumber)
            .ToListAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(list);
        }


        public async Task<PaymentDto> GetByIdAsync(int id)
        {
            var entity = await _paymentRepo.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<PaymentDto>(entity);
        }


        public async Task<TicketDetailDto> CreateAsync(PaymentCreateDto dto)
        {
            var ticket = await _ticketRepo.Query()
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.Id == dto.TicketId);

            if (ticket == null) throw new InvalidOperationException("Ticket no encontrado.");
            if (ticket.Status == TicketStatus.Pagado) throw new InvalidOperationException("El ticket ya está liquidado.");
            if (dto.Amount <= 0) throw new InvalidOperationException("El monto debe ser > 0.");
            if (dto.Amount > ticket.PendingAmount) throw new InvalidOperationException("El pago excede el saldo pendiente.");

            var nextNumber = (ticket.Payments?.Max(p => (int?)p.PaymentNumber) ?? 0) + 1;
            var folio = FolioGenerator.GeneratePaymentFolio(ticket.Folio, nextNumber);

            var payment = new Payment
            {
                TicketId = ticket.Id,
                PaymentNumber = nextNumber,
                Folio = folio,
                Amount = dto.Amount,
                PaidAt = dto.PaidAt ?? DateTime.UtcNow,
                Notes = dto.Notes
            };

            await _paymentRepo.AddAsync(payment);

            ticket.PendingAmount -= payment.Amount;
            if (ticket.PendingAmount == 0)
            {
                ticket.Status = TicketStatus.Pagado;
                ticket.SettledAt = DateTime.UtcNow;
            }
            _ticketRepo.Update(ticket);
            await _ticketRepo.SaveChangesAsync();

            var updated = await _ticketRepo.Query()
                .Include(t => t.Lines.Select(l => l.Product))
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.Id == ticket.Id);

            var dtoOut = _mapper.Map<TicketDetailDto>(updated);
            dtoOut.Payments = dtoOut.Payments
                .OrderByDescending(p => p.PaidAt)
                .ThenByDescending(p => p.PaymentNumber)
                .ToList();

            return dtoOut;
        }
    }
}