using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRUEBA_TECNICA_IMOVS.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly Context _context;

        public TicketService(Context context)
        {
            _context = context;
        }

        public IEnumerable<TicketResponseDto> GetAll()
        {
            return _context.Tickets.Select(t => new TicketResponseDto
            {
                Id = t.Id,
                Folio = t.Folio,
                CreatedAt = t.CreatedDate,
                PaidAt = t.PaidDate,
                TotalAmount = t.TotalAmount,
                PendingAmount = t.PendingAmount,
                Status = t.Status.ToString(),
                Details = t.Details.Select(d => new TicketDetailResponseDto
                {
                    ProductName = d.Product.Name,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    Total = d.Quantity * d.UnitPrice
                }).ToList()
            }).ToList();
        }

        public TicketResponseDto GetById(Guid id)
        {
            var ticket = _context.Tickets.Find(id);
            if (ticket == null)
                throw new KeyNotFoundException("Ticket no encontrado");

            return MapTicketToDto(ticket);
        }

        public TicketResponseDto Create(TicketCreateDto dto)
        {
            if (dto == null || dto.Details == null || !dto.Details.Any())
                throw new ArgumentException("El ticket debe tener al menos un detalle");

            // Generar folio
            string folio = $"TKT-{DateTime.Now:yyyyMMddHHmmss}";

            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Folio = folio,
                CreatedDate = DateTime.Now,
                Status = TicketStatus.PorPagar,
                Details = new List<TicketDetail>(),
                Payments = new List<Payment>()
            };

            decimal totalAmount = 0;

            foreach (var item in dto.Details)
            {
                var product = _context.Products.Find(item.ProductId);
                if (product == null)
                    throw new KeyNotFoundException($"Producto con Id {item.ProductId} no encontrado");

                var detail = new TicketDetail
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                ticket.Details.Add(detail);
                totalAmount += detail.Quantity * detail.UnitPrice;
            }

            ticket.TotalAmount = totalAmount;
            ticket.PendingAmount = totalAmount;

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return MapTicketToDto(ticket);
        }

        private TicketResponseDto MapTicketToDto(Ticket ticket)
        {
            return new TicketResponseDto
            {
                Id = ticket.Id,
                Folio = ticket.Folio,
                CreatedAt = ticket.CreatedDate,
                PaidAt = ticket.PaidDate,
                TotalAmount = ticket.TotalAmount,
                PendingAmount = ticket.PendingAmount,
                Status = ticket.Status.ToString(),
                Details = ticket.Details.Select(d => new TicketDetailResponseDto
                {
                    ProductName = d.Product.Name,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    Total = d.Quantity * d.UnitPrice
                }).ToList()
            };
        }
    }
}
