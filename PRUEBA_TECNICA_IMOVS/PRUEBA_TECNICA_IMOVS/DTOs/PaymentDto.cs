using System;
using System.ComponentModel.DataAnnotations;


namespace PRUEBA_TECNICA_IMOVS.Api.Models.DTOs
{
    public class PaymentCreateDto
    {
        [Required] public int TicketId { get; set; }
        [Range(0.01, 999999999)] public decimal Amount { get; set; }
        public DateTime? PaidAt { get; set; }
        [StringLength(256)] public string Notes { get; set; }
    }


    public class PaymentDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Folio { get; set; }
        public int PaymentNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public string Notes { get; set; }
    }
}