using System.ComponentModel.DataAnnotations;


namespace CompanyManagement.Api.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required, StringLength(32)] public string Sku { get; set; }
        [Required, StringLength(128)] public string Name { get; set; }
        [Range(0.01, 999999999)] public decimal UnitPrice { get; set; }
        public bool IsActive { get; set; } = true;
    }
}