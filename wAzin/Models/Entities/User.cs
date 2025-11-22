

namespace wAzin.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<SavingPlan> Savingplan { get; set; } = new List<SavingPlan>();
    }
}
