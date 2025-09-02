using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Repositories.Interfaces
{
    public interface ITicketDetailRepository
    {
        TicketDetail GetAll();
        TicketDetail GetById(int id);
        TicketDetail Create(TicketDetail ticketDetail);
        TicketDetail Update(int id, TicketDetail ticketDetail);
        TicketDetail Delete(int id);
    }
}