using Microsoft.EntityFrameworkCore;
using wAzin.Core.Entities;
using wAzin.Models.Data;
using wAzin.Repositories.Interfaces;

namespace wAzin.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly _Dbcontext _context;

        public CategoryRepository(_Dbcontext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
