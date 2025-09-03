using System.Collections.Generic;
using System.Threading.Tasks;
using PRUEBA_TECNICA_IMOVS.Api.Models.DTOs;


namespace PRUEBA_TECNICA_IMOVS.Api.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductDto dto);
        Task<ProductDto> UpdateAsync(int id, ProductDto dto);
        Task DeleteAsync(int id);
    }
}