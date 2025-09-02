using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public interface IProductService
    {
            Product GetAll();
            Product GetById(int id);
            Product Create(CreateProductDto createProductDto);
            Product Update(int id, UpdateProductDto updateProductDto);
            Product Delete(int id);
    }
}