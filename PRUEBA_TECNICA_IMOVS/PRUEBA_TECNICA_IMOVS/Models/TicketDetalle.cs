using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    [Table("TicketDetalles")]
    public class TicketDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketDetalleId { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [NotMapped]
        public decimal Subtotal => Cantidad * PrecioUnitario;


        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }
    }
}