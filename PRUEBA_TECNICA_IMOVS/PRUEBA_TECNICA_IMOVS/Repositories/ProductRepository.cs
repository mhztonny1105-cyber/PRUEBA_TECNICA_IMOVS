using PRUEBA_TECNICA_IMOVS.DTOs;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using PRUEBA_TECNICA_IMOVS.Repositories.Interfaces;

namespace PRUEBA_TECNICA_IMOVS.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Create(Product dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product Update(int id, Product dto)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return null;

            product.Name = dto.Name;
            product.Price = dto.Price;

            _context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return null;

            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }
    }
    }
}