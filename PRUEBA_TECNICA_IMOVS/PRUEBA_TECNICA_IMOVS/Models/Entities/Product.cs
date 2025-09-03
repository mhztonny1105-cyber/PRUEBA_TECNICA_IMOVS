using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CompanyManagement.Api.Models.Entities
{
    public class Product : BaseEntity
    {
        [Required, StringLength(32)]
        [Index("IX_Product_Sku", IsUnique = true)]
        public string Sku { get; set; }


        [Required, StringLength(128)]
        public string Name { get; set; }


        [Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }


        public bool IsActive { get; set; } = true;
    }
}