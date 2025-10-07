using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using departamental.Models;

namespace departamental.Services
{
    public class TicketService
    {
        private readonly ContextoDepa _context = new ContextoDepa();

        public Respuesta<Ticket> CrearTicket(Ticket ticket)
        {
            var respuesta = new Respuesta<Ticket>();

            try
            {
                ticket.Total = ticket.Detalles.Sum(d => d.Subtotal);
                ticket.FechaDeCreacion = DateTime.Now;
                ticket.Estado = "Por pagar";

                _context.Tickets.Add(ticket);
                _context.SaveChanges();

                respuesta.Datos = ticket;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = $"Error al crear el ticket: {ex.Message}";
            }

            return respuesta;
        }

        public Respuesta<IEnumerable<Ticket>> ListarTickets()
        {
            var respuesta = new Respuesta<IEnumerable<Ticket>>();

            try
            {
                respuesta.Datos = _context.Tickets
                    .Include(t => t.Detalles.Select(d => d.Producto))
                    .Include(t => t.Pagos)
                    .ToList();
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        public Respuesta<Ticket> ObtenerTicket(int id)
        {
            var respuesta = new Respuesta<Ticket>();

            var ticket = _context.Tickets
                .Include(t => t.Detalles.Select(d => d.Producto))
                .Include(t => t.Pagos)
                .FirstOrDefault(t => t.Id == id);

            if (ticket == null)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = "Ticket no encontrado.";
                return respuesta;
            }

            respuesta.Datos = ticket;
            return respuesta;
        }
    }
}
