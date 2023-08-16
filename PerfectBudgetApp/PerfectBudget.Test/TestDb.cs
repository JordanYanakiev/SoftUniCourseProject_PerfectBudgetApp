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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            var userManager = new UserManager<IdentityUser>(userStore, null, hasher, null, null, normalizer, null, null, null);

            //Create user01
            this.user01 = new IdentityUser()
            {
                Id = "05580017-67d4-4766-9f1d-3327a26530fd",
                UserName = "someemail@mail.bg",
                NormalizedUserName = "SOMEEMAIL@MAIL.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEKJIzyYhT78c69h+srExBSUAF3SJaPu9PRpeDDXLviaUCrf6GUsQCYejGE933QseIQ=="
            };
            userManager
                .CreateAsync(this.user01, this.user01.UserName)
                .Wait();

            //Create user02
            this.user02 = new IdentityUser()
            {
                Id = "1c6d2885-57e4-4736-8b96-141a3890d399",
                UserName = "some.email@mail.bg",
                NormalizedUserName = "SOME.EMAIL@MAIL.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEDAD9fgJshOHRusNzGKJBkm4NZj0fhrVpnLcf5kNUQG/toW2NDbzZyyAwc3XAc1JxQ=="
            };
            userManager
                .CreateAsync(this.user02, this.user02.UserName)
                .Wait();

            //Create budget01
            this.budget01 = new Budget()
            {
                Id = Guid.NewGuid(),
                Name = "Pari za more",
                Amount = 150000m
            };
            dbContext.Add(budget01);

            //create budget02
            this.budget02 = new Budget()
            {
                Id = Guid.NewGuid(),
                Name = "Pari za hrana",
                Amount = 20000m
            };
            dbContext.Add(budget02);

            //Create budgetExpense01
            this.budgetExpense01 = new BudgetExpense()
            {
                ExpenseId = expense01.Id,
                Expense = this.expense01,
                BudgetId = this.budget01.Id,
                Budget = this.budget01
            };
            dbContext.Add(budgetExpense01);

            //Create budgetExpense02
            this.budgetExpense02 = new BudgetExpense()
            {
                ExpenseId = expense02.Id,
                Expense = this.expense02,
                BudgetId = this.budget02.Id,
                Budget = this.budget02
            };
            dbContext.Add(budgetExpense02);
            

            //Create category01
            this.categoryElectricity = new Category()
            {
                Name = "Electricity"
            };
            dbContext.Add(categoryElectricity);

            //Create category02
            this.categoryGroceries = new Category()
            {
                Name = "Groceries"
            };
            dbContext.Add(categoryGroceries);

            //Create debt01 
            this.debt01 = new Debt()
            {
                Id = Guid.NewGuid(),
                Name = "Pari za more",
                LoanRequester = "John Doe",
                LoanGiver = "John Doe II",
                Amount = 1500m
            };
            dbContext.Add(debt01);
            
            //Create debt02
            this.debt02 = new Debt()
            {
                Id = Guid.NewGuid(),
                Name = "Pari za planina",
                LoanRequester = "John Doe",
                LoanGiver = "John Doe II",
                Amount = 500m
            };
            dbContext.Add(debt02);

            //Create Debt Issuer 01
            this.debtIssuer01 = new DebtIssuer()
            {
                DebtId = Guid.NewGuid(),
                Debt  = debt01,
                DebtIssuerId = user01.Id,
                UserId  = user01
            };
            dbContext.Add(debtIssuer01);

             //Create Debt Issuer 02
            this.debtIssuer02 = new DebtIssuer()
            {
                DebtId = Guid.NewGuid(),
                Debt  = debt02,
                DebtIssuerId = user01.Id,
                UserId  = user01
            };
            dbContext.Add(debtIssuer02);

            //Create debt payment01
            this.debtPayment01 = new DebtPayment()
            {
                Id = Guid.NewGuid(),
                CreditInstallment = 1500m
            };
            dbContext.Add(debtPayment01);

            
            //Create debt payment02
            this.debtPayment02 = new DebtPayment()
            {
                Id = Guid.NewGuid(),
                CreditInstallment = 500m
            };
            dbContext.Add(debtPayment02);

            //Create debtPaymentDebt01
            this.debtPaymentDebt01 = new DebtPaymentDebt()
            {
                DebtId = debt01.Id,
                Debt = debt01,
                DebtInstallmentId = debtPayment01.Id,
                DeptPayment = debtPayment01
            };
            dbContext.Add(debtPaymentDebt01);

            //Create debtPaymentDebt02
            this.debtPaymentDebt02 = new DebtPaymentDebt()
            {
                DebtId = debt02.Id,
                Debt = debt02,
                DebtInstallmentId = debtPayment02.Id,
                DeptPayment = debtPayment02
            };
            dbContext.Add(debtPaymentDebt02);

            //Create debtReceiver01
            this.debtReceiver01 = new DebtReceiver()
            {
                DebtId = debt01.Id,
                Debt = debt01,
                DebtReceiverId = user02.Id,
                UserId = user02
            };
            dbContext.Add(debtReceiver01);
            
            //Create debtReceiver02
            this.debtReceiver02 = new DebtReceiver()
            {
                DebtId = debt02.Id,
                Debt = debt02,
                DebtReceiverId = user02.Id,
                UserId = user02
            };
            dbContext.Add(debtReceiver02);

            this.expense01 = new Expense()
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryElectricity.Id,
                Category = categoryElectricity,
                Amount = debtPayment01.CreditInstallment,
                Description = "Tok",
                BudgetId = budget01.Id,
                Budget = budget01,
                DateOfIssuedExpense = new DateTime(2023, 8, 15)
            };
            dbContext.Add(expense01);
            
            this.expense02 = new Expense()
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryGroceries.Id,
                Category = categoryGroceries,
                Amount = debtPayment01.CreditInstallment,
                Description = "Bread and onion",
                BudgetId = budget01.Id,
                Budget = budget01,
                DateOfIssuedExpense = new DateTime(2023, 8, 20)
            };
            dbContext.Add(expense02);

            this.expenseCategory01 = new ExpenseCategory()
            {
                CategoryId = expense01.CategoryId,
                Category = expense01.Category,
                ExpenseId = expense01.Id,
                Expense = expense01
            };
            dbContext.Add(expenseCategory01);

            this.expenseCategory02 = new ExpenseCategory()
            {
                CategoryId = expense02.CategoryId,
                Category = expense02.Category,
                ExpenseId = expense02.Id,
                Expense = expense02
            };
            dbContext.Add(expenseCategory02);

            this.saving01 = new Saving()
            {
                Id = Guid.NewGuid(),
                Name = "Saving 01",
                Amount = 1000m
            };
            dbContext.Add(saving01);
            
            this.saving02 = new Saving()
            {
                Id = Guid.NewGuid(),
                Name = "Saving 02",
                Amount = 1024m
            };
            dbContext.Add(saving02);

            this.userBudget01 = new UserBudget()
            {
                UserId = user01.Id,
                User = user01,
                BudgetId = budget01.Id,
                Budget = budget01
            };
            dbContext.Add(userBudget01);
            
            this.userBudget02 = new UserBudget()
            {
                UserId = user02.Id,
                User = user02,
                BudgetId = budget02.Id,
                Budget = budget02
            };
            dbContext.Add(userBudget02);

            this.userDebt01 = new UserDebt()
            {
                UserId = user01.Id,
                User = user01,
                DebtId = debt01.Id,
                Debt = debt01
            };
            dbContext.Add(userDebt01);
            
            this.userDebt02 = new UserDebt()
            {
                UserId = user02.Id,
                User = user02,
                DebtId = debt02.Id,
                Debt = debt02
            };
            dbContext.Add(userDebt02);

            this.userExpense01 = new UserExpense()
            {
                UserId = user01.Id,
                User = user01,
                ExpenseId = expense01.Id,
                Expense = expense01
            };
            dbContext.Add(userExpense01);
            
            this.userExpense02 = new UserExpense()
            {
                UserId = user02.Id,
                User = user02,
                ExpenseId = expense02.Id,
                Expense = expense02
            };
            dbContext.Add(userExpense02);


            this.userSaving01 = new UserSaving()
            {
                UserId = user01.Id,
                User = user01,
                SavingsId = saving01.Id,
                Saving = saving01
            };
            dbContext.Add(userSaving01);
            
            this.userSaving02 = new UserSaving()
            {
                UserId = user02.Id,
                User = user02,
                SavingsId = saving02.Id,
                Saving = saving02
            };
            dbContext.Add(userSaving02);





        }




















    }
}
