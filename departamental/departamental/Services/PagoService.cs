using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using departamental.Models;

namespace departamental.Services
{
    public class PagoService
    {
        private readonly ContextoDepa _context = new ContextoDepa();

        public Respuesta<Pago> RegistrarPago(int ticketId, Pago pago)
        {
            var respuesta = new Respuesta<Pago>();

            try
            {
                var ticket = _context.Tickets.Include(t => t.Pagos).FirstOrDefault(t => t.Id == ticketId);

                if (ticket == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "Ticket no encontrado.";
                    return respuesta;
                }

                pago.TicketId = ticketId;
                pago.NumeroDePago = ticket.Pagos.Count + 1;
                pago.FechaDePago = DateTime.Now;

                _context.Pagos.Add(pago);
                _context.SaveChanges();

                // Verificar si el ticket quedó pagado
                decimal pagado = _context.Pagos.Where(p => p.TicketId == ticketId).Sum(p => p.Monto);

                if (pagado >= ticket.Total)
                {
                    ticket.Estado = "Pagado";
                    ticket.FechaDeLiquidacion = DateTime.Now;
                    _context.SaveChanges();
                }

                respuesta.Datos = pago;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        public Respuesta<IEnumerable<Pago>> ListarPagosPorTicket(int ticketId)
        {
            var respuesta = new Respuesta<IEnumerable<Pago>>();

            try
            {
                respuesta.Datos = _context.Pagos
                    .Where(p => p.TicketId == ticketId)
                    .OrderByDescending(p => p.FechaDePago)
                    .ToList();
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
