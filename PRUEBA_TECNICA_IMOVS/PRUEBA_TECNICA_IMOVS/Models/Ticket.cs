using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal MontoPendiente { get; set; }
        public string Estatus { get; set; }
        public string Folio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}