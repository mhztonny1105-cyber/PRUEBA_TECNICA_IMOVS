using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class DetalleTicketsController : ApiController
    {
        private Context db = new Context();

        // GET: api/DetalleTickets
        public IHttpActionResult GetDetalleTickets()
        {
            var detalles = db.DetalleTickets.ToList();
            return Ok(detalles);
        }

        // GET: api/DetalleTickets/1
        public IHttpActionResult GetDetalleTicket(int id)
        {
            var detalle = db.DetalleTickets.Find(id);
            if (detalle == null)
            {
                return NotFound();
            }
            return Ok(detalle);
        }

        // POST: api/DetalleTickets
        [HttpPost]
        public IHttpActionResult PostDetalleTicket(DetalleTicket detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Aquí está la lógica de negocio
            // 1. Calcula el precio total del detalle
            detalle.PrecioTotal = detalle.Cantidad * detalle.PrecioUnitario;

            db.DetalleTickets.Add(detalle);
            db.SaveChanges();

            // 2. Busca el ticket al que pertenece este detalle
            var ticketPadre = db.Tickets.Find(detalle.TicketId);
            if (ticketPadre != null)
            {
                // 3. Recalcula el monto total del ticket
                ticketPadre.PrecioTotal = db.DetalleTickets.Where(d => d.TicketId == ticketPadre.Id).Sum(d => d.PrecioTotal);

                // 4. Guarda los cambios en el ticket
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = detalle.Id }, detalle);
        }

        // PUT: api/DetalleTickets/1
        [HttpPut]
        public IHttpActionResult PutDetalleTicket(int id, DetalleTicket detalle)
        {
            if (!ModelState.IsValid || id != detalle.Id)
            {
                return BadRequest(ModelState);
            }

            // Lógica de actualización
            detalle.PrecioTotal = detalle.Cantidad * detalle.PrecioUnitario;
            db.Entry(detalle).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            // Recalcula el precio del ticket padre después de la actualización
            var ticketPadre = db.Tickets.Find(detalle.TicketId);
            if (ticketPadre != null)
            {
                ticketPadre.PrecioTotal = db.DetalleTickets.Where(d => d.TicketId == ticketPadre.Id).Sum(d => d.PrecioTotal);
                db.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/DetalleTickets/1
        [HttpDelete]
        public IHttpActionResult DeleteDetalleTicket(int id)
        {
            var detalle = db.DetalleTickets.Find(id);
            if (detalle == null)
            {
                return NotFound();
            }

            db.DetalleTickets.Remove(detalle);
            db.SaveChanges();

            // Recalcula el precio del ticket padre después de eliminar un detalle
            var ticketPadre = db.Tickets.Find(detalle.TicketId);
            if (ticketPadre != null)
            {
                ticketPadre.PrecioTotal = db.DetalleTickets.Where(d => d.TicketId == ticketPadre.Id).Sum(d => d.PrecioTotal);
                db.SaveChanges();
            }

            return Ok(detalle);
        }
    }
}