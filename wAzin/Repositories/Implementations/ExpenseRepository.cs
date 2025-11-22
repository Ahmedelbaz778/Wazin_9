using Microsoft.EntityFrameworkCore;
using wAzin.Core.Entities;
using wAzin.Models.Data;
using wAzin.Repositories.Interfaces;

namespace wAzin.Repositories.Implementations
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        private readonly _Dbcontext _context;

        public ExpenseRepository(_Dbcontext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int userId)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .Include(e => e.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategoryAsync(int categoryId)
        {
            return await _context.Expenses
                .Where(e => e.CategoryId == categoryId)
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .Include(e => e.Category)
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalExpensesForUserAsync(int userId)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .SumAsync(e => e.Amount);
        }
    }
}
