using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Ticket GetAll();
        Ticket GetById(int id);
        Ticket Create(Ticket ticket);
        Ticket Update(int id, Ticket ticket);
        Ticket Delete(int id);
    }
}