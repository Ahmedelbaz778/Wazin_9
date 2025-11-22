using wAzin.Core.Entities;


namespace wAzin.Repositories.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
      
        Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int userId);
        Task<IEnumerable<Expense>> GetExpensesByCategoryAsync(int categoryId);
        Task<IEnumerable<Expense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalExpensesForUserAsync(int userId);
    }
}
