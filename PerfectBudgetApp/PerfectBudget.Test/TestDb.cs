
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Data;
using PerfectBudget.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace PerfectBudget.Test
{
    public class TestDb
    {

        private string uniqueDbName;

        public TestDb()
        {
            this.uniqueDbName = "PerfectBudget-TestDb";
            //this.SeedDatabase();
        }

        public Budget budget01 { get; private set; }
        public Budget budget02 { get; private set; }
        public BudgetExpense budgetExpense01 { get; private set; }
        public BudgetExpense budgetExpense02 { get; private set; }
        public Category categoryElectricity { get; private set; }
        public Category categoryGroceries { get; private set; }
        public Debt debt01 { get; private set; }
        public Debt debt02 { get; private set; }
        public DebtIssuer debtIssuer01 { get; private set; }
        public DebtIssuer debtIssuer02 { get; private set; }
        public DebtPayment debtPayment01 { get; private set; }
        public DebtPayment debtPayment02 { get; private set; }
        public DebtReceiver debtReceiver01 { get; private set;}
        public DebtReceiver debtReceiver02 { get; private set;}
        public DebtPaymentDebt debtPaymentDebt01 { get; private set; }
        public DebtPaymentDebt debtPaymentDebt02 { get; private set; }
        public Expense expense01 { get; private set; }
        public Expense expense02 { get; private set; }
        public ExpenseCategory expenseCategory01 { get; private set;}
        public ExpenseCategory expenseCategory02 { get; private set;}
        public Saving saving01 { get; private set; }
        public Saving saving02 { get; private set; }
        public IdentityUser user01 { get; private set; }
        public IdentityUser user02 { get; private set; }
        public UserBudget userBudget01 { get; private set; }
        public UserBudget userBudget02 { get; private set; }
        public UserDebt userDebt01 { get; private set; }
        public UserDebt userDebt02 { get; private set; }
        public UserExpense userExpense01 { get; private set; }
        public UserExpense userExpense02 { get; private set; }
        public UserExpense userExpense03 { get; private set; }
        public UserExpense userExpense04 { get; private set; }
        public UserExpense userExpense05 { get; private set; }
        public UserExpense userExpense06 { get; private set; }
        public UserSaving userSaving01 { get; private set; }
        public UserSaving userSaving02 { get; private set; }

        public BudgetDbContext CreateDbContext()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<PerfectBudgetApp.Data.BudgetDbContext>();
            var optionsBuilder = new DbContextOptionsBuilder<BudgetDbContext>();

            // Uncomment to use an in-memory database from Entity Framework
            optionsBuilder.UseInMemoryDatabase(uniqueDbName);

            return new PerfectBudgetApp.Data.BudgetDbContext(optionsBuilder.Options);
        }

        private void SeedDatabase()
        {
            var dbContext = this.CreateDbContext();
            var userStore = new UserStore<IdentityUser>(dbContext);
            var hasher = new PasswordHasher<IdentityUser>();
            var normalizer = new UpperInvariantLookupNormalizer();
            var userManager = new UserManager<IdentityUser>(
                userStore, null, hasher, null, null, normalizer, null, null, null);

        }




















    }
}
