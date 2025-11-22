using Microsoft.EntityFrameworkCore;
using wAzin.Core.Entities;
using wAzin.Models.Data;
using wAzin.Repositories.Interfaces;

namespace wAzin.Repositories.Implementations
{
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        private readonly _Dbcontext _context;

        public IncomeRepository(_Dbcontext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Income>> GetIncomesByUserIdAsync(int userId)
        {
            return await _context.Incomes
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Income>> GetIncomesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Incomes
                .Where(i => i.Date >= startDate && i.Date <= endDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalIncomeForUserAsync(int userId)
        {
            return await _context.Incomes
                .Where(i => i.UserId == userId)
                .SumAsync(i => i.Amount);
        }
    }
}
