using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Repositories
{
    public class TicketRepository: ITicketRepository
    {
    using PRUEBA_TECNICA_IMOVS.Models;
    using PRUEBA_TECNICA_IMOVS.Models.Entities;
    using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    namespace PRUEBA_TECNICA_IMOVS.Repositories
    {
        public class TicketRepository : ITicketRepository
        {
            private readonly Context _context;

            public TicketRepository(Context context)
            {
                _context = context;
            }

            public IEnumerable<Ticket> GetAll()
            {
                return _context.Tickets
                    .Include(t => t.Details.Select(d => d.Product))
                    .Include(t => t.Payments)
                    .ToList();
            }

            public Ticket GetById(int id)
            {
                return _context.Tickets
                    .Include(t => t.Details.Select(d => d.Product))
                    .Include(t => t.Payments)
                    .FirstOrDefault(t => t.Id == id);
            }

            public Ticket Create(Ticket ticket)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return ticket;
            }

            public Ticket Update(int id,Ticket ticket)
            {
                
            }

            public Ticket Delete(int id)
            {
                var ticket = _context.Tickets.Find(id);
                if (ticket == null) return null;

                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
                return ticket;
            }
        }
    }
}