using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        public string Status { get; set; } = "Pending";

        public int PaysQuantity { get; set; } = 1;
        public int PaysRemaining { get; set; } = 1;
    }
}
