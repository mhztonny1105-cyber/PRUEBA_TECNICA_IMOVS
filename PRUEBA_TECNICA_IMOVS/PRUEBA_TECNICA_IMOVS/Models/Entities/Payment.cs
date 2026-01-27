

using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        [Required]
        public Guid TicketId { get; set; }

        public int PaymentNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Folio { get; set; }

        [Range(1, 999999)]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public virtual Ticket Ticket { get; set; }
    }


}