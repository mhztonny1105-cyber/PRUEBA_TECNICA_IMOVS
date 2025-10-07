using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace departamental.Models
{
    public class Respuesta<T>
    {
        public bool Exito { get; set; } = true;
        public string Mensaje { get; set; } = "Operación Exitosa";
        public T Datos { get; set; }
    }
}