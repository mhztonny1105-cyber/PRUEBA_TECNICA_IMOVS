

using System;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Range(0, 999999)]
        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }

}