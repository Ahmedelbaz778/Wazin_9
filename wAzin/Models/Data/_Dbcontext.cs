using Microsoft.EntityFrameworkCore;
using wAzin.Core.Entities;


namespace wAzin.Models.Data
{
    public class _Dbcontext : DbContext
    {
        public _Dbcontext(DbContextOptions<_Dbcontext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<SavingPlan> Budgets { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Income> Incomes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.SavingPlan)
                .WithMany(b => b.Expenses)
                .HasForeignKey(e => e.SavingPlanId)
                .OnDelete(DeleteBehavior.SetNull);

           
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Expense>()
                .Property(e => e.Date)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Income>()
                .Property(i => i.Date)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<SavingPlan>()
                .Property(b => b.StartDate)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<SavingPlan>()
                .Property(b => b.EndDate)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
