using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("ticket_details")]
    public class TicketDetail
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Subtotal { get; set; }
        
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}