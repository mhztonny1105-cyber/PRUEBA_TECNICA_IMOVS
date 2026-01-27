using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/tickets")]
    public class TicketsController : ApiController
    {
        private readonly Context _context = new Context();

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateTickets(CreateTicketDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Details == null || !dto.Details.Any())
                return BadRequest("El ticket debe de tener al menos un producto.");

            var ticket = new Ticket
            {
                Folio = dto.Folio,
                CreatedAt = DateTime.Now,
                Status = TicketStatus.Pending
            };

            decimal total = 0;

            ticket.Details = dto.Details.Select(d =>
            {
                var product = _context.Products.Find(d.ProductId);
                if (product == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                var lineTotal = product.Price * d.Quantity;
                total += lineTotal;

                return new TicketDetail
                {
                    ProductId = product.Id,
                    Quantity = d.Quantity,
                    UnitPrice = product.Price,
                    Total = lineTotal
                };
            }).ToList();

            ticket.TotalAmount = total;
            ticket.PendingAmount = total;

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, ticket);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTicketsById(int id)
        {
            var ticket = _context.Tickets
                .Include("Details")
                .Include("Payments")
                .FirstOrDefault(t => t.Id == id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }
    }
}
