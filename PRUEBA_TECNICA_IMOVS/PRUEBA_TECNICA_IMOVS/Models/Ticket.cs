using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Ticket 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Folio { get; set; }

        public DateTime? PaidAt { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public decimal PendingAmount { get; set; }

        [Required]
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}