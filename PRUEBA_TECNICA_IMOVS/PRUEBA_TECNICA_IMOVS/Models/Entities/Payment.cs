using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PRUEBA_TECNICA_IMOVS.Api.Models.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        [Index("IX_Payment_Ticket_PaymentNumber", 1, IsUnique = true)]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        [Required]
        [Index("IX_Payment_Ticket_PaymentNumber", 2, IsUnique = true)]
        public int PaymentNumber { get; set; }


        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }


        public DateTime PaidAt { get; set; }


        [StringLength(256)]
        public string Notes { get; set; }
    }
}