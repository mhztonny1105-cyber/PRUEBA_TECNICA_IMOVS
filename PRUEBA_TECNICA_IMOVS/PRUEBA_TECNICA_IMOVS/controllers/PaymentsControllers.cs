using PRUEBA_TECNICA_IMOVS.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    [RoutePrefix("api/payments")]
    public class PaymentsController : ApiController
    {
        private readonly Context _context = new Context();

        [HttpPost]
        [Route("")]
        public IHttpActionResult CreatePayments(CreatePaymentDto dto)
        {
            if (dto == null || dto.Amount <= 0)
                return BadRequest("Invalid payment data.");

            var ticket = _context.Tickets
                .Include("Payments")
                .FirstOrDefault(t => t.Id == dto.TicketId);

            if (ticket == null)
                return NotFound();

            if (ticket.Status == TicketStatus.Paid)
                return BadRequest("Ticket already paid.");

            if (dto.Amount > ticket.PendingAmount)
                return BadRequest("Payment exceeds pending amount.");

            var payment = new Payment
            {
                TicketId = ticket.Id,
                Amount = dto.Amount,
                PaymentDate = DateTime.Now,
                PaymentNumber = ticket.Payments.Count + 1,
                Folio = $"PAY-{DateTime.Now.Ticks}"
            };

            ticket.PendingAmount -= dto.Amount;

            if (ticket.PendingAmount == 0)
            {
                ticket.Status = TicketStatus.Paid;
                ticket.PaidAt = DateTime.Now;
            }
            else
            {
                ticket.Status = TicketStatus.InProgress;
            }

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, payment);
        }

        [HttpGet]
        [Route("ticket/{ticketId:int}")]
        public IHttpActionResult GetPaymentsByTicket(int ticketId)
        {
            var payments = _context.Payments
                .Where(p => p.TicketId == ticketId)
                .OrderBy(p => p.PaymentNumber)
                .ToList();

            return Ok(payments);
        }
    }
}
