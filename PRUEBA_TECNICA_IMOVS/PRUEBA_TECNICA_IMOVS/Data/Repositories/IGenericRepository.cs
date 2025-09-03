using System.Linq;
using System.Threading.Tasks;


namespace PRUEBA_TECNICA_IMOVS.Api.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}
