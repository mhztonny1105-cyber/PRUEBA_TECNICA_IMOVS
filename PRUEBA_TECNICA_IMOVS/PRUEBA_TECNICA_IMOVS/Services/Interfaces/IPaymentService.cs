using System;
using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;

namespace PRUEBA_TECNICA_IMOVS.Services.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<PaymentResponseDto> GetByTicket(Guid ticketId);
        PaymentResponseDto GetById(Guid id);
        void Create(PaymentCreateDto dto);
    }
}
