using wAzin.Core.Entities;


namespace wAzin.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> IsEmailExistAsync(string email);
    }
}
