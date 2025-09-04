using System.Collections.Generic;
using System.Linq;
using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Services
{
    public class ProductService
    {
        private readonly Context _db = new Context();

        public IEnumerable<Product> GetAll() => _db.Products.OrderByDescending(p => p.Id).ToList();
        public Product GetById(int id) => _db.Products.Find(id);
        public Product Create(Product e) { _db.Products.Add(e); _db.SaveChanges(); return e; }
        public Product Update(int id, Product e)
        {
            var dbp = _db.Products.Find(id); if (dbp == null) return null;
            dbp.SKU = e.SKU; dbp.Name = e.Name; dbp.UnitPrice = e.UnitPrice; dbp.IsActive = e.IsActive;
            _db.SaveChanges(); return dbp;
        }
        public bool Delete(int id) { var dbp = _db.Products.Find(id); if (dbp == null) return false; _db.Products.Remove(dbp); _db.SaveChanges(); return true; }
    }
}
