using Microsoft.EntityFrameworkCore;
using wAzin.Core.Entities;
using wAzin.Models.Data;
using wAzin.Repositories.Interfaces;

namespace wAzin.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly _Dbcontext _context;

        public UserRepository(_Dbcontext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
