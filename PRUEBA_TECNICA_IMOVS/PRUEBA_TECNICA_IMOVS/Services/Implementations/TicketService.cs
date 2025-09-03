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

    public class TicketService : ITicketService
    {
        private readonly IGenericRepository<Ticket> _ticketRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<TicketLine> _lineRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IMapper _mapper;

        public TicketService(
            IGenericRepository<Ticket> ticketRepo,
            IGenericRepository<Product> productRepo,
            IGenericRepository<TicketLine> lineRepo,
            IGenericRepository<Payment> paymentRepo,
            IMapper mapper)
        {
            _ticketRepo = ticketRepo;
            _productRepo = productRepo;
            _lineRepo = lineRepo;
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        // ====== ITicketService ======
        public async Task<IEnumerable<TicketListItemDto>> GetAllAsync()
        {
            var list = await _ticketRepo.Query()
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<TicketListItemDto>>(list);
        }

        public async Task<TicketDetailDto> GetByIdAsync(int id)
        {
            var entity = await _ticketRepo.Query()
                .Include(t => t.Lines.Select(l => l.Product))
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (entity == null) return null;

            var dto = _mapper.Map<TicketDetailDto>(entity);
            if (dto.Payments != null)
            {
                dto.Payments = dto.Payments
                    .OrderByDescending(p => p.PaidAt)
                    .ThenByDescending(p => p.PaymentNumber)
                    .ToList();
            }
            return dto;
        }

        public async Task<TicketDetailDto> CreateAsync(TicketCreateDto dto)
        {
            if (dto?.Lines == null || dto.Lines.Count == 0)
                throw new InvalidOperationException("El ticket debe contener al menos una línea.");

            var ticket = new Ticket
            {
                Folio = FolioGenerator.GenerateTicketFolio(),
                Status = TicketStatus.PorPagar,
                Total = 0m,
                PendingAmount = 0m
            };

            await _ticketRepo.AddAsync(ticket); // para tener Id

            decimal total = 0m;
            var productIds = dto.Lines.Select(x => x.ProductId).ToList();
            var products = await _productRepo.Query()
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            foreach (var line in dto.Lines)
            {
                var prod = products.FirstOrDefault(p => p.Id == line.ProductId)
                           ?? throw new InvalidOperationException($"Producto {line.ProductId} no existe.");
                if (line.Quantity <= 0)
                    throw new InvalidOperationException("Cantidad debe ser > 0.");

                var unit = prod.UnitPrice;
                var lineTotal = unit * line.Quantity;
                total += lineTotal;

                var entityLine = new TicketLine
                {
                    TicketId = ticket.Id,
                    ProductId = prod.Id,
                    Quantity = line.Quantity,
                    UnitPriceSnapshot = unit,
                    LineTotal = lineTotal
                };
                await _lineRepo.AddAsync(entityLine);
            }

            ticket.Total = total;
            ticket.PendingAmount = total;
            _ticketRepo.Update(ticket);
            await _ticketRepo.SaveChangesAsync();

            // Detalle
            var updated = await _ticketRepo.Query()
                .Include(t => t.Lines.Select(l => l.Product))
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.Id == ticket.Id);

            return _mapper.Map<TicketDetailDto>(updated);
        }

        public async Task<TicketDetailDto> UpdateAsync(int id)
        {
            var ticket = await _ticketRepo.GetByIdAsync(id);
            if (ticket == null) return null;

            // (aquí actualizarías campos del encabezado si existieran)
            await _ticketRepo.SaveChangesAsync();

            var updated = await _ticketRepo.Query()
                .Include(t => t.Lines.Select(l => l.Product))
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<TicketDetailDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await _ticketRepo.Query()
                .Include(t => t.Payments)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return;

            if (ticket.Payments != null && ticket.Payments.Any())
                throw new InvalidOperationException("No se puede eliminar un ticket con pagos registrados.");

            _ticketRepo.Remove(ticket);
            await _ticketRepo.SaveChangesAsync();
        }
    }
}
