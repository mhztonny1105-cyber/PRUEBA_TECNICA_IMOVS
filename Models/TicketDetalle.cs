using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class TicketDetalle
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Range(1, 9999, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Range(0.01, 999999.99)]
        public decimal PrecioUnitario { get; set; }

        [Range(0.01, 9999999.99)]
        public decimal Subtotal { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Producto Producto { get; set; }
    }
}