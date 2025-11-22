using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using wAzin.Repositories.Interfaces;
using wAzin.Models.Data;

namespace wAzin.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly _Dbcontext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(_Dbcontext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
