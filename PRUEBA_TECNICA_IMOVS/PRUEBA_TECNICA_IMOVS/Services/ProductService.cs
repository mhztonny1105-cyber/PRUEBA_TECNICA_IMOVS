using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product GetAll()
        {
            var products = _repository.GetAll();
            return products;
        }

        public Product GetById(int id)
        {
            var product = _repository.GetById(id);
            return product;
        }

        public Product Create(CreateProductDto createProductDto)
        {
            var product = _repository.Create(createProductDto);
            return product;
        }

        public Product Update(int id, UpdateProductDto updateProductDto)
        {
            var updatedProduct = _repository.Update(id, updateProductDto);
            return updatedProduct;
        }

        public Product Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}