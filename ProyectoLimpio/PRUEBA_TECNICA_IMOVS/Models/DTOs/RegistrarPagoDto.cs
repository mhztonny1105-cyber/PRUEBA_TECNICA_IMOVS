namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class RegistrarPagoDto
    {
        public long TicketId { get; set; }
        public long UsuarioId { get; set; }
        public decimal MontoPago { get; set; }
    }
}
