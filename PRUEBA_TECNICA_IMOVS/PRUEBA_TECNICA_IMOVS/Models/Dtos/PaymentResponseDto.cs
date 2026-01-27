using System;

namespace PRUEBA_TECNICA_IMOVS.Models.DTOs
{
    public class PaymentResponseDto
    {
        public Guid Id { get; set; }
        public string Folio { get; set; }
        public int PaymentNumber { get; set; }

        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
