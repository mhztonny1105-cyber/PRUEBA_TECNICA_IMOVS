using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Folio { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaLiquidacion { get; set; }

        [StringLength(20)]
        public string Estatus { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<TicketDetalle> Detalles { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}