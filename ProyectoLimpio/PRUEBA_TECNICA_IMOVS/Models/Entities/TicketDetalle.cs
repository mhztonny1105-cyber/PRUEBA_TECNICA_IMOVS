using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("TicketsDetalle")]
    public class TicketDetalle
    {
        [Key]
        public long TicketDetalleId { get; set; }

        [Required]
        public long TicketId { get; set; }

        [Required]
        public long ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal TotalFila { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }
    }
}
