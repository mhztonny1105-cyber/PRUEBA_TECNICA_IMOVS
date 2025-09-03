using System.Collections.Generic;
using System.Threading.Tasks;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;


namespace PRUEBA_TECNICA_IMOVS.Api.Services.Contracts
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetByIdAsync(int id);
        Task<TicketDetailDto> CreateAsync(PaymentCreateDto dto); // retorna estado actualizado del Ticket
        Task DeleteAsync(int id); // eliminar pago y recalcular ticket
    }
}