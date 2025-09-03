using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PRUEBA_TECNICA_IMOVS.Api.Models.Entities;


namespace PRUEBA_TECNICA_IMOVS.Api.Models.DTOs
{
    public class TicketCreateDto
    {
        [Required]
        public List<TicketLineCreateDto> Lines { get; set; }
    }


    public class TicketLineCreateDto
    {
        [Required] public int ProductId { get; set; }
        [Range(1, int.MaxValue)] public int Quantity { get; set; }
    }


    public class TicketListItemDto
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public DateTime CreatedAt { get; set; }
        public TicketStatus Status { get; set; }
        public decimal Total { get; set; }
        public decimal PendingAmount { get; set; }
    }


    public class TicketDetailDto
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SettledAt { get; set; }
        public TicketStatus Status { get; set; }
        public decimal Total { get; set; }
        public decimal PendingAmount { get; set; }
        public List<TicketLineDto> Lines { get; set; }
        public List<PaymentDto> Payments { get; set; }
    }


    public class TicketLineDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPriceSnapshot { get; set; }
        public decimal LineTotal { get; set; }
    }
}