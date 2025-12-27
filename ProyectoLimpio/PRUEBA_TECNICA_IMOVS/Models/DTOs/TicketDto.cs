using System;
using System.Collections.Generic;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class TicketDto
    {
        public long TicketId { get; set; }
        public string FolioTicket { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public decimal TotalTicket { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal MontoPendiente { get; set; }
        public string Estatus { get; set; }
        public List<TicketDetalleDto> Detalles { get; set; } = new List<TicketDetalleDto>();
    }
}
