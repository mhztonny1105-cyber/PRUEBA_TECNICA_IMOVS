using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Repositories
{
    public class TicketDetailRepository: ITicketDetailRepository
    {
        private readonly Context _context;

        public TicketDetailRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<TicketDetail> GetAll()
        {
            return _context.TicketDetails
                .Include(td => td.Product)
                .Include(td => td.Ticket)
                .ToList();
        }

        public TicketDetail GetById(int id)
        {
            return _context.TicketDetails
                .Include(td => td.Product)
                .Include(td => td.Ticket)
                .FirstOrDefault(td => td.Id == id);
        }

        public TicketDetail Create(TicketDetail detail)
        {
            _context.TicketDetails.Add(detail);
            _context.SaveChanges();
            return detail;
        }

        public TicketDetail Update(int id, TicketDetail detail)
        {
            
        }

        public TicketDetail Delete(int id)
        {
            var detail = _context.TicketDetails.Find(id);
            if (detail == null) return null;

            _context.TicketDetails.Remove(detail);
            _context.SaveChanges();
            return detail;
        }
    }
    }
}