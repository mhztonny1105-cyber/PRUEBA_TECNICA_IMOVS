using System.Collections.Generic;
using System.Threading.Tasks;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;


namespace PRUEBA_TECNICA_IMOVS.Api.Services.Contracts
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketListItemDto>> GetAllAsync();
        Task<TicketDetailDto> GetByIdAsync(int id);
        Task<TicketDetailDto> CreateAsync(TicketCreateDto dto);
        Task<TicketDetailDto> UpdateAsync(int id /* futuro: dto encabezado */);
        Task DeleteAsync(int id);
    }
}