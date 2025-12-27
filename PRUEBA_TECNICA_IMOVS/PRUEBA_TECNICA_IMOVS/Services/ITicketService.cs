using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface ITicketService
    {
        TicketDto CrearTicket(CrearTicketDto ticketDto);
        TicketDto GetTicketById(long id);
        IEnumerable<TicketDto> GetAllTickets();
        PagoDto RegistrarPago(RegistrarPagoDto pagoDto);
        IEnumerable<PagoDto> GetHistorialPagos(long ticketId);
    }
}
