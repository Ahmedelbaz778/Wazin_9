namespace wAzin.Core.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
