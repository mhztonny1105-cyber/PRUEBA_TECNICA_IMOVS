using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace departamental.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Folio { get; set; }

        [Required]
        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaDeLiquidacion { get; set; }

        [Required, StringLength(20)]
        public string Estado { get; set; } = "Pendiente de pago";

        [Required]
        public decimal Total { get; set; }

        public virtual ICollection<DetalleTicket> Detalles { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}