using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaLiquidacion { get; set; }

        [Range(0, 9999999)]
        public decimal Total { get; set; }

        [Range(0, 9999999)]
        public decimal Pendiente { get; set; }

        [Required]
        [StringLength(20)]
        public string Estatus { get; set; } // "Por pagar" o "Pagado"

        public virtual ICollection<TicketDetalle> Detalles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}