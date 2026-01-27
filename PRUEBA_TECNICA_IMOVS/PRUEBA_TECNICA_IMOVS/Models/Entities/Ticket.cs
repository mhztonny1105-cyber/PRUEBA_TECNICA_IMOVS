

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.Models.Entities
{
    public class Ticket
    {
            public Guid Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Folio { get; set; }

            public DateTime CreatedDate { get; set; }
            public DateTime? PaidDate { get; set; }  

            public decimal TotalAmount { get; set; }
            public decimal PendingAmount { get; set; }

            public TicketStatus Status { get; set; }

            public virtual ICollection<TicketDetail> Details { get; set; }
            public virtual ICollection<Payment> Payments { get; set; }
      }

    public enum TicketStatus
    {
        PorPagar = 1,
        Pagado = 2
    }

}