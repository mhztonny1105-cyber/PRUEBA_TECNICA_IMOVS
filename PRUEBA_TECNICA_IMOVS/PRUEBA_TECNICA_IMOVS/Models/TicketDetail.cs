using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class TicketDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Total { get; set; }

        [JsonIgnore]
        [ForeignKey ("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [ForeignKey ("ProductId")]
        public virtual Product Product { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}