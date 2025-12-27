using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public long ProductoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [StringLength(20)]
        public string Estatus { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<TicketDetalle> Detalles { get; set; } = new List<TicketDetalle>();
    }
}
