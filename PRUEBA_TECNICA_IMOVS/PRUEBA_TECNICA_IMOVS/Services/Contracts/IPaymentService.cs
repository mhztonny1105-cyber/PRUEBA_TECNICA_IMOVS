using AutoMapper;
using PRUEBA_TECNICA_IMOVS.Api.Data.Repositories;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Api.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Api.Services.Contracts;


namespace PRUEBA_TECNICA_IMOVS.Api.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;

    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetByIdAsync(int id);
        Task<TicketDetailDto> CreateAsync(PaymentCreateDto dto);
        Task DeleteAsync(int id);
    }
}