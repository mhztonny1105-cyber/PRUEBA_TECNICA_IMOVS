using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
