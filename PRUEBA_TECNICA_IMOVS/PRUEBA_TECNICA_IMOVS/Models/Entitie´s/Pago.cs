using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities {
    public class Pago {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }

        [Required]
        [StringLength(50)]
        public string Folio { get; set; }

        [Required]
        public int NumeroPago { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;

        public virtual Ticket Ticket { get; set; }
    }
}
