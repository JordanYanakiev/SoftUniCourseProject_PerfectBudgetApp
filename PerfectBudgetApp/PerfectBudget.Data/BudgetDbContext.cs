using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Data.Models;
using System.Reflection.Emit;

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
        public DbSet<DebtIssuer> DebtsIssuers { get; set; }
        public DbSet<DebtReceiver> DebtsReceivers { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Set foreign keys
            //Set foreign keys

            builder.Entity<DebtReceiver>()
                .HasKey(be => new { be.DebtId, be.DebtReceiverId });

            builder.Entity<DebtIssuer>()
                .HasKey(be => new { be.DebtId, be.DebtIssuerId });

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

            builder.Entity<ExpenseCategory>()
                .HasKey(c => new { c.CategoryId, c.ExpenseId });
            #endregion

            #region Set precision to decimals
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
            #endregion

            #region Set delete behavior for BudgetExpense
            //Set delete behavior
            builder.Entity<BudgetExpense>()
                .HasOne(b => b.Budget)
                .WithMany(b => b.BudgetsExpenses)
                .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<BudgetExpense>()
            //    .HasOne(b => b.Expense)
            //    .WithMany(b => b.BudgetsExpenses)
            //    .OnDelete(DeleteBehavior.Restrict);
            #endregion


            #region Enter Default Categories in Category Entity
            builder.Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Groceries"
                },
                new Category()
                {
                    Id = 2, 
                    Name = "Utilities"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Car"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Loan"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Internet"
                },
                new Category() 
                {
                    Id = 6,
                    Name = "Mobile"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Leasing"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Electricity"
                },
                new Category()
                {
                    Id = 9,
                    Name = "Water"
                });
            #endregion


            base.OnModelCreating(builder);
        }


    }
}