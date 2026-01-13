using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities {
    public class Ticket {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Folio { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaLiquidacion { get; set; }

        public decimal Total { get; set; }

        [Required]
        [StringLength(20)]
        public string Estatus { get; set; } 

        public virtual ICollection<TicketDetalle> Detalles { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
