using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("CotizacionDetalle")]
    public class CotizacionDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UnidadesCotizadas { get; set; }
        public decimal PrecioTotal { get; set; }
        public int CotizacionId { get; set; }
        public int ProductoId { get; set; }
        

        public virtual Cotizacion Cotizacion { get; set; }
        public virtual Producto Producto { get; set; }
    }
}