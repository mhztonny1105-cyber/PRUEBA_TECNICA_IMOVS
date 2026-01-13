using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services.Interfaces {
    public interface ITicketService {
        IEnumerable<Ticket> GetAll();
        Ticket GetById(int id);
        Ticket Create(Ticket ticket);
        void AddPago(int ticketId, Pago pago);
    }
}
