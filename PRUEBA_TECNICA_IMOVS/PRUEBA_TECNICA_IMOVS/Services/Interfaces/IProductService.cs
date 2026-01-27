using System;
using System.Collections.Generic;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;

namespace PRUEBA_TECNICA_IMOVS.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetAll();
        ProductResponseDto GetById(Guid id);
        void Create(ProductCreateDto dto);
        void Update(Guid id, ProductCreateDto dto);
        void Delete(Guid id);
    }
}
