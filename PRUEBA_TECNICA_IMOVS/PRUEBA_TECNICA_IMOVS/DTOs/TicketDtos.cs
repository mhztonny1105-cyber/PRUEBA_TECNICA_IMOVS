using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRUEBA_TECNICA_IMOVS.DTOs
{
    public class TicketItemCreateDto
    {
        [Required] public int ProductId { get; set; }
        [Range(1, int.MaxValue)] public int Quantity { get; set; }
    }

    public class CreateTicketDto
    {
        [Required] public int CustomerId { get; set; }
        [Required] public List<TicketItemCreateDto> Items { get; set; }
        public string Folio { get; set; }
    }

    public class PaymentCreateDto
    {
        [Range(0.01, double.MaxValue)] public decimal Amount { get; set; }
    }
}
