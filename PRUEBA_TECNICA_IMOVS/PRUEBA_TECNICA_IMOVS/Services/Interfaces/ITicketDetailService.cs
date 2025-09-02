using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface ITicketDetailService
    {
        TicketDetail GetAll();
        TicketDetail GetById(int id);
        TicketDetail Create(CreateTicketDetailDto createTicketDetailDto);
        TicketDetail Update(int id, UpdateTicketDetailDto updateTicketDetailDto);
        TicketDetail Delete(int id);
    }
}