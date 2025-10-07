using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace departamental.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public int Stock { get; set; }

        public bool Activo { get; set; } = true;
    }
}