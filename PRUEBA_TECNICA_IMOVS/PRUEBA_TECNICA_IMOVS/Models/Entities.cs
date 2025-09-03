using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Nombre { get; set; }

        [Column(TypeName = "decimal")]
        [Range(0, 999999)]
        public decimal PrecioUnitario { get; set; }
    }

    public class Ticket
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Folio { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaLiquidacion { get; set; }

        [Required, StringLength(20)]
        public string Estatus { get; set; } = "Por pagar";

        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }

        public virtual ICollection<TicketDetalle> Detalles { get; set; } = new List<TicketDetalle>();
        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    }

    public class TicketDetalle
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        [Range(1, 999999)]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Subtotal { get; set; }
    }
    
    public class Pago
    {
        public int Id { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public int NumeroPago { get; set; }

        [Required, StringLength(40)]
        public string Folio { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal")]
        [Range(0.01, 999999)]
        public decimal Monto { get; set; }
    }
    
}