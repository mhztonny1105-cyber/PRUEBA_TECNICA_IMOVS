using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface ITicketService
    {
        void CrearTicket(Ticket ticket, List<TicketDetalle> detalles);
        decimal CalcularMontoPendiente(int ticketId);

        void RegistrarPago(int ticketId, decimal monto);
        IEnumerable<Pago> ObtenerHistorialPagos(int ticketId);
    }
}