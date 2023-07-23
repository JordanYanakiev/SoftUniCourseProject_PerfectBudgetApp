using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Expenses;
using PerfectBudgetApp.Models.Statistics;

namespace PerfectBudgetApp.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly BudgetDbContext budgetDbContext;

        public StatisticsService(BudgetDbContext _budgetDbContext)
        {
            budgetDbContext = _budgetDbContext;
        }

        public async Task<IEnumerable<ExpenseStatsViewModel>> GetAllExpensesLastSevenDays(string userId)
        {
            DateTime today = DateTime.Now;
            var expenseCategoriesByDate = await budgetDbContext.UsersExpenses
             .Where(x => x.UserId == userId && x.Expense.DateOfIssuedExpense >= today + TimeSpan.FromDays(-7))
             .Select(e => new ExpenseStatsViewModel()
             {
                 ExpenseId = e.ExpenseId,
                 ExpenceAmount = e.Expense.Amount,
                 DateOfExpense = e.Expense.DateOfIssuedExpense,
                 Description = e.Expense.Description,
                 BudgetId = e.Expense.BudgetId,
                 CategoryName = e.Expense.Category.Name
             })
             .ToListAsync();

            return expenseCategoriesByDate;
        }

        public async Task<IEnumerable<ExpenseStatsViewModel>> GetAllExpensesLastThirtyDays(string userId)
        {
            DateTime today = DateTime.Now;
            var expenseCategoriesByDate = await budgetDbContext.UsersExpenses
             .Where(x => x.UserId == userId && x.Expense.DateOfIssuedExpense >= today + TimeSpan.FromDays(-30))
             .Select(e => new ExpenseStatsViewModel()
             {
                 ExpenseId = e.ExpenseId,
                 ExpenceAmount = e.Expense.Amount,
                 DateOfExpense = e.Expense.DateOfIssuedExpense,
                 Description = e.Expense.Description,
                 BudgetId = e.Expense.BudgetId,
                 CategoryName = e.Expense.Category.Name
             })
             .ToListAsync();

            return expenseCategoriesByDate;
        }

        public async Task<List<object>> GetAllExpenseSortedByCategories(IEnumerable<ExpenseStatsViewModel> expenses)
        {
            List<string> result = new List<string>();
            result.Add("Groceries");          //0
            result.Add("Utilities");          //1
            result.Add("Car");                //2
            result.Add("Loan");               //3
            result.Add("Internet");           //4
            result.Add("Mobile");             //5
            result.Add("Leasing");            //6
            result.Add("Electricity");        //7
            result.Add("Water");              //8

            //Get all spendings for 30 days by categories
            List<decimal> values = new List<decimal> { 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m };
            foreach (var expense in expenses)
            {
                string category = expense.CategoryName;
                decimal expenseValue = expense.ExpenceAmount;

                if (category == "Groceries")
                {
                    values[0] += expenseValue;
                }
                else if (category == "Utilities")
                {
                    values[1] += expenseValue;
                }
                else if (category == "Car")
                {
                    values[2] += expenseValue;
                }
                else if (category == "Loan")
                {
                    values[3] += expenseValue;
                }
                else if (category == "Internet")
                {
                    values[4] += expenseValue;
                }
                else if (category == "Mobile")
                {
                    values[5] += expenseValue;
                }
                else if (category == "Leasing")
                {
                    values[6] += expenseValue;
                }
                else if (category == "Electricity")
                {
                    values[7] += expenseValue;
                }
                else if (category == "Water")
                {
                    values[8] += expenseValue;
                }

            }

            List<object> list= new List<object>();
            list.Add(result);
            list.Add(values);

            return list;
        }
    }
}