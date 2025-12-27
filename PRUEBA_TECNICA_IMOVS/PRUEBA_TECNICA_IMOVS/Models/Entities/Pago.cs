using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Pagos")]
    public class Pago
    {
        [Key]
        public long PagoId { get; set; }

        [Required]
        public long TicketId { get; set; }

        [Required]
        public long UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string FolioPago { get; set; }

        [Required]
        public int NumeroPago { get; set; }

        [Required]
        public decimal MontoPago { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}
