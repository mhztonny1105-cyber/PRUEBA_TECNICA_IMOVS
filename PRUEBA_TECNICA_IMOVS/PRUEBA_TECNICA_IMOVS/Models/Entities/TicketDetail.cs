


using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class TicketDetail
    {
        public Guid Id { get; set; }

        [Required]
        public Guid TicketId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Product Product { get; set; }
    }

}