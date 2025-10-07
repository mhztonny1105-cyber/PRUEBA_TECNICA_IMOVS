using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace departamental.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        [Required]
        public int NumeroDePago { get; set; }

        [Required, StringLength(20)]
        public string Folio { get; set; }

        [Required]
        public DateTime FechaDePago { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(10,2")]
        public decimal Monto { get; set; }

    }
}