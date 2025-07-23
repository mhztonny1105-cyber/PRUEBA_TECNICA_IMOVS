using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Cotizacion")]
    public class Cotizacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public decimal TotalCotizacion { get; set; }
        public decimal IVA { get; set; }
        public bool EstadoVenta { get; set; }
        // true = confirmada, false = pendiente

        public virtual ICollection<CotizacionDetalle> Detalles { get; set; }
    }
}