using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Producto
    {
        // Propiedad que será la clave principal de la tabla.
        // Será el identificador único para cada producto.
        public int Id { get; set; }

        // Propiedad para el nombre del producto.
        public string Nombre { get; set; }

        // Propiedad para el precio de cada producto.
        public decimal Precio { get; set; }
    }
}