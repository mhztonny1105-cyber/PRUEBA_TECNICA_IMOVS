using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.DTOs;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRUEBA_TECNICA_IMOVS.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly Context context;

        public ProductService(Context context)
        {
            this.context = context;
        }

        public IEnumerable<ProductResponseDto> GetAll()
        {
            return context.Products
                .Where(p => p.IsActive)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();
        }

        public ProductResponseDto GetById(Guid id)
        {
            return context.Products
                .Where(p => p.Id == id && p.IsActive)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefault();
        }

        public void Create(ProductCreateDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                IsActive = true
            };

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Guid id, ProductCreateDto dto)
        {
            var product = context.Products.Find(id);
            if (product == null || !product.IsActive)
                return;

            product.Name = dto.Name;
            product.Price = dto.Price;

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = context.Products.Find(id);
            if (product == null)
                return;

            product.IsActive = false;
            context.SaveChanges();
        }
    }
}
