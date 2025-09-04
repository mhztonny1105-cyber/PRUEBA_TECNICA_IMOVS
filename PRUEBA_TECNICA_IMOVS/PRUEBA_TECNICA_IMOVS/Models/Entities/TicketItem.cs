using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class TicketItem
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [NotMapped] public decimal Total => UnitPrice * Quantity;
    }
}
