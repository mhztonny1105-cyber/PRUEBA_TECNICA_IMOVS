

using System;
using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;



namespace PRUEBA_TECNICA_IMOVS.Services.Implementations
{

    public class TicketService : ITicketService
    {
        private readonly Context context;

        public TicketService(Context context)
        {
            this.context = context;
        }

        public Ticket Create(TicketCreateDto dto)
        {
            if (dto.Details == null || !dto.Details.Any())
            throw new Exception("El ticket debe contener al menos un producto");

            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Folio = $"TCK-{DateTime.Now:yyyyMMddHHmmss}",
                CreatedDate = DateTime.Now,
                Status = TicketStatus.PorPagar,
                Details = new List<TicketDetail>()
            };

            decimal total = 0;

            foreach (var item in dto.Details)
            {
                var product = context.Products.Find(item.ProductId);
                if (product == null)
                    throw new Exception("Producto no encontrado");

                var detail = new TicketDetail
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    TotalPrice = product.Price * item.Quantity
                };

                total += detail.TotalPrice;
                ticket.Details.Add(detail);
            }

            ticket.TotalAmount = total;
            ticket.PendingAmount = total;

            context.Tickets.Add(ticket);
            context.SaveChanges();

            return ticket;
        }

        public Ticket GetById(Guid id)
        {
            return context.Tickets
                .Include("Details.Product")
                .Include("Payments")
                .FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return context.Tickets
                .OrderByDescending(t => t.CreatedDate)
                .ToList();
        }
    }

}