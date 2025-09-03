using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace PRUEBA_TECNICA_IMOVS.Api.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _ctx;
        protected readonly DbSet<T> _set;


        public GenericRepository(AppDbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }


        public IQueryable<T> Query() => _set;
        public Task<T> GetByIdAsync(int id) => _set.FindAsync(id);
        public async Task AddAsync(T entity) { _set.Add(entity); await _ctx.SaveChangesAsync(); }
        public void Update(T entity) { _ctx.Entry(entity).State = EntityState.Modified; }
        public void Remove(T entity) { _set.Remove(entity); }
        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();
    }
}