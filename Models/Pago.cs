using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class Pago
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        [Required]
        public int NumeroPago { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Monto { get; set; }

        [JsonIgnore]
        public virtual Ticket Ticket { get; set; }
    }
}