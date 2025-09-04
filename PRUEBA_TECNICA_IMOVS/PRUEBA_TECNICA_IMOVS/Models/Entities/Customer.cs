using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(32)]
        public string Phone { get; set; }
    }
}
