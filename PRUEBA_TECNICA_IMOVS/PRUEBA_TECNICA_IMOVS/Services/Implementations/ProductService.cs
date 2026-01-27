


using PRUEBA_TECNICA_IMOVS.Models;
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

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Where(p => p.IsActive).ToList();
        }

        public Product GetById(Guid id)
        {
            return context.Products.Find(id);
        }

        public void Create(Product product)
        {
            product.Id = Guid.NewGuid();
            product.IsActive = true;

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = context.Products.Find(id);
            if (product == null) return;

            product.IsActive = false;
            context.SaveChanges();
        }

    }

}