using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("tickets")]
    public enum PaymentStatus
    {
        Pending,
        Payed
    }
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Folio { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? PayedAt { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Total { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        
        public virtual ICollection<TicketDetail> Details { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}