using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization; 
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class DetalleTicket
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }

        [IgnoreDataMember] 
        public virtual Ticket Ticket { get; set; }
        [IgnoreDataMember]
        public virtual Producto Producto { get; set; }
    }
}