using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Data.Models;

namespace PerfectBudgetApp.Data
{
    public class BudgetDbContext : IdentityDbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            : base(options) { }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetExpense> BudgetsExpenses { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<UserBudget> UsersBudgets { get; set; }
        public DbSet<UserDebt> UsersDebts { get; set; }
        public DbSet<UserExpense> UsersExpenses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Set foreign keys

            builder.Entity<BudgetExpense>()
                .HasKey(be => new { be.BudgetId, be.ExpenseId });

            builder.Entity<UserBudget>()
                .HasKey(ub => new { ub.BudgetId, ub.UserId});

            builder.Entity<UserDebt>()
                .HasKey(ud => new {ud.UserId, ud.DebtId});

            builder.Entity<UserExpense>()
                .HasKey(ue => new {ue.UserId, ue.ExpenseId});

            builder.Entity<DebtPaymentDebt>()
                .HasKey(dpd => new { dpd.DebtInstallmentId, dpd.DebtId });

            //Set precision to decimals

            builder.Entity<Budget>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Entity<Debt>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            builder.Entity<DebtPayment>()
                .Property(x => x.CreditInstallment)
                .HasPrecision(18, 2);

            builder.Entity<Expense>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);

            //Set delete behavior
           
        }


    }
}