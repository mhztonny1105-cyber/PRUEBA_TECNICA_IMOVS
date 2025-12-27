using System.Collections.Generic;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class CrearTicketDto
    {
        public long UsuarioId { get; set; }
        public List<CrearTicketDetalleDto> Detalles { get; set; } = new List<CrearTicketDetalleDto>();
    }
}
