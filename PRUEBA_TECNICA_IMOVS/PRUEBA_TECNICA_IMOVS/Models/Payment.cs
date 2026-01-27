using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Folio { get; set; }

        [Required]
        public int PaymentNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [ForeignKey ("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}