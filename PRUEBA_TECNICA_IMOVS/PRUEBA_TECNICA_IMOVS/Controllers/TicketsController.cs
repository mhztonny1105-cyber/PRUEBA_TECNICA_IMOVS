using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class TicketsController : ApiController
    {
        // Instancia de tu contexto de base de datos
        private Context db = new Context();

        // GET: api/Tickets
        public IHttpActionResult GetTickets()
        {
            var tickets = db.Tickets.ToList();
            return Ok(tickets);
        }

        // GET: api/Tickets/1
        public IHttpActionResult GetTicket(int id)
        {
            var ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public IHttpActionResult PostTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lógica de negocio: Inicializa el monto pendiente y el estatus
            ticket.PrecioTotal = 0;
            ticket.MontoPendiente = 0;
            ticket.Estatus = "Por pagar";
            ticket.FechaCreacion = DateTime.Now;

            db.Tickets.Add(ticket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ticket.Id }, ticket);
        }

        // PUT: api/Tickets/1
        [HttpPut]
        public IHttpActionResult PutTicket(int id, Ticket ticket)
        {
            if (!ModelState.IsValid || id != ticket.Id)
            {
                return BadRequest(ModelState);
            }

            db.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Tickets/1
        [HttpDelete]
        public IHttpActionResult DeleteTicket(int id)
        {
            var ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            db.Tickets.Remove(ticket);
            db.SaveChanges();

            return Ok(ticket);
        }

        // GET: api/Tickets/1/Pagos
        [HttpGet]
        [Route("api/tickets/{id}/pagos")]
        public IHttpActionResult GetPagosByTicketId(int id)
        {
            var pagos = db.Pagos
                          .Where(p => p.TicketId == id)
                          .OrderByDescending(p => p.Fecha) // Ordena del más reciente al más antiguo
                          .ToList();

            if (pagos == null || !pagos.Any())
            {
                return NotFound();
            }

            return Ok(pagos);
        }
    }
}