namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class TicketDetalleDto
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalFila { get; set; }
    }
}
