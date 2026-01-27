using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public bool IsActive { get; set; } = true;
    }
}