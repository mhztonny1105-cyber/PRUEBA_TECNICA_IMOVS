using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Folio { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public TicketStatus Status { get; set; } = TicketStatus.PorPagar;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }

        public virtual ICollection<TicketItem> Items { get; set; } = new HashSet<TicketItem>();
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();

        [NotMapped] public decimal Total => Items?.Sum(i => i.Total) ?? 0m;
        [NotMapped] public decimal TotalPaid => Payments?.Sum(p => p.Amount) ?? 0m;
        [NotMapped] public decimal Pending => Total - TotalPaid;
    }
}
