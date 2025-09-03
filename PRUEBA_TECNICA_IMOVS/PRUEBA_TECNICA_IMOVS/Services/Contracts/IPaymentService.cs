using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Api.Models.DTOs;


namespace CompanyManagement.Api.Services.Contracts
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetByIdAsync(int id);
        Task<TicketDetailDto> CreateAsync(PaymentCreateDto dto); // retorna estado actualizado del Ticket
        Task DeleteAsync(int id); // eliminar pago y recalcular ticket
    }
}