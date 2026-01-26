using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaLiquidacion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPagado { get; set; } = 0;

        [NotMapped]
        public decimal MontoPendiente => MontoTotal - MontoPagado;

        [Required]
        [StringLength(20)]
        public string Estatus { get; set; } = "PorPagar"; // "PorPagar" o "Pagado"

        [StringLength(100)]
        public string Cliente { get; set; }

        // Relaciones
        public virtual ICollection<TicketDetalle> Detalles { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }

        public Ticket()
        {
            Detalles = new List<TicketDetalle>();
            Pagos = new List<Pago>();
            FechaCreacion = DateTime.Now;
        }
    }
}