using PRUEBA_TECNICA_IMOVS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA_TECNICA_IMOVS.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}
