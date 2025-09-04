using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        [Required]
        public int PaymentNumber { get; set; } // 1..n por ticket

        [Required, StringLength(40)]
        public string Folio { get; set; } // Ej: P-{FolioTicket}-{N}

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    }
}
