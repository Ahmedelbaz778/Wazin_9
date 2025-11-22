using wAzin.Core.Entities;

namespace wAzin.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category?> GetCategoryByNameAsync(string name);
    }
}
