using System;
using System.Collections.Generic;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class TicketResponseDto
    {
        public Guid Id { get; set; }
        public string Folio { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal PendingAmount { get; set; }

        public string Status { get; set; }

        public List<TicketDetailResponseDto> Details { get; set; }
    }
}
