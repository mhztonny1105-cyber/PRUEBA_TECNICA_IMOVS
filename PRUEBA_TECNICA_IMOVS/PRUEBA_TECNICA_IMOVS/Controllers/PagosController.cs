using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Controllers
{
    public class PagosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Pagos
        public IHttpActionResult GetPagos()
        {
            var pagos = db.Pagos.ToList();
            return Ok(pagos);
        }

        // GET: api/Pagos/1
        public IHttpActionResult GetPago(int id)
        {
            var pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return NotFound();
            }
            return Ok(pago);
        }

        // POST: api/Pagos
        [HttpPost]
        public IHttpActionResult PostPago(Pago pago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lógica de negocio: Inicializa la fecha del pago antes de guardarlo
            pago.Fecha = DateTime.Now;

            db.Pagos.Add(pago);
            db.SaveChanges();

            // Lógica de negocio para actualizar el ticket
            var ticket = db.Tickets.Find(pago.TicketId);
            if (ticket != null)
            {
                // Actualiza el monto pendiente
                ticket.MontoPendiente -= pago.Monto;

                // Actualiza el estatus a "Pagado" si el monto pendiente es <= 0
                if (ticket.MontoPendiente <= 0)
                {
                    ticket.Estatus = "Pagado";
                }

                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = pago.Id }, pago);
        }

        // PUT: api/Pagos/1
        [HttpPut]
        public IHttpActionResult PutPago(int id, Pago pago)
        {
            if (!ModelState.IsValid || id != pago.Id)
            {
                return BadRequest(ModelState);
            }

            db.Entry(pago).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            // Aquí podrías agregar lógica para recalcular el monto pendiente
            // y el estatus del ticket si un pago se modifica, aunque el POST es más crítico
            var ticket = db.Tickets.Find(pago.TicketId);
            if (ticket != null)
            {
                // Recalcula el monto pendiente del ticket sumando todos los pagos
                var totalPagos = db.Pagos.Where(p => p.TicketId == ticket.Id).Sum(p => p.Monto);
                ticket.MontoPendiente = ticket.PrecioTotal - totalPagos;

                // Actualiza el estatus
                if (ticket.MontoPendiente <= 0)
                {
                    ticket.Estatus = "Pagado";
                }
                else
                {
                    ticket.Estatus = "Por pagar";
                }

                db.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Pagos/1
        [HttpDelete]
        public IHttpActionResult DeletePago(int id)
        {
            var pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return NotFound();
            }

            db.Pagos.Remove(pago);
            db.SaveChanges();

            // Recalcula el monto pendiente y el estatus del ticket
            var ticket = db.Tickets.Find(pago.TicketId);
            if (ticket != null)
            {
                var totalPagos = db.Pagos.Where(p => p.TicketId == ticket.Id).Sum(p => p.Monto);
                ticket.MontoPendiente = ticket.PrecioTotal - totalPagos;

                if (ticket.MontoPendiente <= 0)
                {
                    ticket.Estatus = "Pagado";
                }
                else
                {
                    ticket.Estatus = "Por pagar";
                }

                db.SaveChanges();
            }

            return Ok(pago);
        }
    }
}