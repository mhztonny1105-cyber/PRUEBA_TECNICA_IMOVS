using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public long TicketId { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string FolioTicket { get; set; }

        [Required]
        public long EstatusTicketId { get; set; }

        [Required]
        public long CreadoPor { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaLiquidacion { get; set; }

        [Required]
        public decimal TotalTicket { get; set; }

        [Required]
        public decimal MontoPagado { get; set; }

        [Required]
        public decimal MontoPendiente { get; set; }

        [ForeignKey("EstatusTicketId")]
        public virtual EstatusTicket EstatusTicket { get; set; }

        [ForeignKey("CreadoPor")]
        public virtual Usuario UsuarioCreador { get; set; }

        public virtual ICollection<TicketDetalle> Detalles { get; set; } = new List<TicketDetalle>();
        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
