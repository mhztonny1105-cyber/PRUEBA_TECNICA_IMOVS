using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int StockDisponible { get; set; }
        public bool Estatus { get; set; } 
    }
}