using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    [Table("Pagos")]
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        [Required]
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        [Required]
        public int NumeroPago { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required]
        public DateTime FechaPago { get; set; } = DateTime.Now;

        [StringLength(200)]
        public string Comentarios { get; set; }

        // Navegación
        public virtual Ticket Ticket { get; set; }
    }
}