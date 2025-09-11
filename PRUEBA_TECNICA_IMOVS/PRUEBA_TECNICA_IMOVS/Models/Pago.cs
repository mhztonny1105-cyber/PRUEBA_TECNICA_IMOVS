using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization; 
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public decimal Monto { get; set; }
        public string FormaPago { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }

        [IgnoreDataMember] 
        public virtual Ticket Ticket { get; set; }
    }
}