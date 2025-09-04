using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    [Table("DetallesTicket")]
    public class DetalleTicket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        [Required]
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioTotal => Cantidad * PrecioUnitario;

        // Navegación
        public virtual Ticket Ticket { get; set; }
        public virtual Producto Producto { get; set; }
    }
}