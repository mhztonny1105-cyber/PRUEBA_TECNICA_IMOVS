using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CompanyManagement.Api.Models.Entities
{
    public class TicketLine : BaseEntity
    {
        [Required]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }


        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


        [Required]
        public int Quantity { get; set; }


        [Column(TypeName = "decimal")]
        public decimal UnitPriceSnapshot { get; set; }


        [Column(TypeName = "decimal")]
        public decimal LineTotal { get; set; }
    }
}