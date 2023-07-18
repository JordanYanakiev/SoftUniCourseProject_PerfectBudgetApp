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

        public async Task<IEnumerable<ExpenseStatsViewModel>> GetAllExpensesBydates(string userId)
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

        public Task<Dictionary<string, decimal>> GetAllExpenseSortedByCategories(IEnumerable<ExpenseStatsViewModel> expenses)
        {
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            result.Add("Groceries", 0m);
            result.Add("Utilities", 0m);
            result.Add("Car", 0m);
            result.Add("Loan", 0m);
            result.Add("Internet", 0m);
            result.Add("Mobile", 0m);
            result.Add("Leasing", 0m);
            result.Add("Electricity", 0m);
            result.Add("Water", 0m);

            foreach (var expense in expenses)
            {
                string category = expense.CategoryName;
                decimal expenseValue = expense.ExpenceAmount;

                if (category == "Groceries")
                {
                    result["Groceries"] += expenseValue;
                }
                if (category == "Utilities") ;
                if (category == "Car") ;
                if (category == "Loan") ;
                if (category == "Internet") ;
                if (category == "Mobile") ;
                if (category == "Leasing") ;
                if (category == "Electricity") ;
                if (category == "Water")
                {
                    result["Water"] += expenseValue;
                }

            }



            throw new NotImplementedException();
        }
    }
}