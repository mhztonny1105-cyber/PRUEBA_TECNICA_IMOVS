using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CompanyManagement.Api.Models.Entities
{
    public class Ticket : BaseEntity
    {
        [Required, StringLength(64)]
        [Index("IX_Ticket_Folio", IsUnique = true)]
        public string Folio { get; set; }


        public DateTime? SettledAt { get; set; }


        [Required]
        public TicketStatus Status { get; set; } = TicketStatus.PorPagar;


        [Column(TypeName = "decimal")]
        public decimal Total { get; set; }


        [Column(TypeName = "decimal")]
        public decimal PendingAmount { get; set; }


        public virtual ICollection<TicketLine> Lines { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }


    public enum TicketStatus
    {
        PorPagar = 0,
        Pagado = 1
    }
}