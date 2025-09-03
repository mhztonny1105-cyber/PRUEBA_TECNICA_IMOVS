using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PRUEBA_TECNICA_IMOVS.Api.Models.Entities
{
    public class Payment : BaseEntity
    {
        [Required]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }


        [Required, StringLength(64)]
        [Index("IX_Payment_Folio", IsUnique = true)]
        public string Folio { get; set; }


        // Secuencial por Ticket
        [Index("IX_Payment_Ticket_PaymentNumber", IsUnique = true, Order = 1)]
        public int TicketId_ForIndex
        {
            get => TicketId;
            private set { /* EF index backing */ }
        }


        [Index("IX_Payment_Ticket_PaymentNumber", IsUnique = true, Order = 2)]
        public int PaymentNumber { get; set; }


        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }


        public DateTime PaidAt { get; set; }


        [StringLength(256)]
        public string Notes { get; set; }
    }
}