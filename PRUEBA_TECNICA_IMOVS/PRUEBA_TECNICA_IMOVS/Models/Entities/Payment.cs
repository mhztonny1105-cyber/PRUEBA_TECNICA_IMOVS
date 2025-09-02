using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("payments")]
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        [MaxLength(20)]
        public string PaymentFolio { get; set; }

        [Required]
        public int PaymentNumber { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}