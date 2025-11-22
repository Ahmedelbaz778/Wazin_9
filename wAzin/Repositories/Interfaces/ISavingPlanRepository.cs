using wAzin.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace wAzin.Repositories.Interfaces
{
    public interface ISavingPlanRepository : IRepository<SavingPlan>
    {
        Task<SavingPlan?> GetBudgetByUserIdAsync(int userId);
        Task<IEnumerable<SavingPlan>> GetActiveBudgetsAsync();
        Task<bool> IsBudgetExceededAsync(int userId);
    }
}
