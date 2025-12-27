namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class ProductoDto
    {
        public long ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Estatus { get; set; }
    }
}
