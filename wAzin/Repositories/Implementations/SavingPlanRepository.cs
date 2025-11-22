using Microsoft.EntityFrameworkCore;
using wAzin.Core.Entities;
using wAzin.Models.Data;
using wAzin.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wAzin.Repositories.Implementations
{
    public class SavingPlanRepository : Repository<SavingPlan>, ISavingPlanRepository
    {
        private readonly _Dbcontext _context;

        public SavingPlanRepository(_Dbcontext context) : base(context)
        {
            _context = context;
        }

        public async Task<SavingPlan?> GetBudgetByUserIdAsync(int userId)
        {
            return await _context.Budgets.FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task<IEnumerable<SavingPlan>> GetActiveBudgetsAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.Budgets
                .Where(b => b.StartDate <= now && b.EndDate >= now)
                .ToListAsync();
        }

        public async Task<bool> IsBudgetExceededAsync(int userId)
        {
            var budget = await GetBudgetByUserIdAsync(userId);
            if (budget == null) return false;

            var totalExpenses = await _context.Expenses
                .Where(e => e.UserId == userId)
                .SumAsync(e => e.Amount);

            return totalExpenses > budget.LimitAmount;
        }
    }
}
