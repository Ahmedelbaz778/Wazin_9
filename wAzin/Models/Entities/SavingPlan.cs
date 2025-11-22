namespace wAzin.Core.Entities
{
    public class SavingPlan
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal LimitAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
