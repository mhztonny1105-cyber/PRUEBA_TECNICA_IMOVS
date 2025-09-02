using PRUEBA_TECNICA_IMOVS.Models.Entities;

namespace PRUEBA_TECNICA_IMOVS.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetAll();
        Product GetById(int id);
        Product Create(Product product);
        Product Update(int id, Product product);
        Product Delete(int id);
    }
}