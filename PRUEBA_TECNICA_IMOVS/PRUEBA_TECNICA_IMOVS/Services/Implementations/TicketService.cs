using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyManagement.Api.Data.Repositories;
using CompanyManagement.Api.Models.DTOs;
using CompanyManagement.Api.Models.Entities;
using CompanyManagement.Api.Services.Contracts;


namespace CompanyManagement.Api.Services.Implementations
{
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
            dto.Payments = dto.Payments
            .OrderByDescending(p => p.PaidAt)
            .ThenByDescending(p => p.PaymentNumber)
            .ToList();
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
            }