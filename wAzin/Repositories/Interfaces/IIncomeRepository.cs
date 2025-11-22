using wAzin.Core.Entities;


namespace wAzin.Repositories.Interfaces
{
    public interface IIncomeRepository : IRepository<Income>
    {
        Task<IEnumerable<Income>> GetIncomesByUserIdAsync(int userId);
        Task<IEnumerable<Income>> GetIncomesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalIncomeForUserAsync(int userId);
    }
}
