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
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        [Required]
        [StringLength(100)]
        public string Cliente { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoTotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPagado { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPendiente => MontoTotal - MontoPagado;

        [Required]
        [StringLength(20)]
        public string Estatus { get; set; } = "Por Pagar";

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaLiquidacion { get; set; }

        // Navegación
        public virtual ICollection<DetalleTicket> DetallesTicket { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }

        public Ticket()
        {
            DetallesTicket = new List<DetalleTicket>();
            Pagos = new List<Pago>();
        }
    }
}