using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface ITicketService
    {
        Ticket GetAll();
        Ticket GetById(int id);
        Ticket Create(CreateTicketDto createTicketDto);
        Ticket Update(int id, UpdateTicketDto updateTicketDto);
        Ticket Delete(int id);
    }
}