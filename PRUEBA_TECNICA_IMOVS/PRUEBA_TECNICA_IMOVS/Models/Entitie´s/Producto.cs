using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities {
    public class Producto {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true;

        public virtual ICollection<TicketDetalle> TicketDetalles { get; set; }
    }
}
