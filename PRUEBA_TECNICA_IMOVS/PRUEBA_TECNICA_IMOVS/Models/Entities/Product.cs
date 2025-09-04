using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(32)]
        public string SKU { get; set; }

        [Required, StringLength(128)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
