using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    [Table("Pagos")]
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public int NumeroPago { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Monto { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }


        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        public Pago()
        {
            FechaPago = DateTime.Now;
        }
    }
}