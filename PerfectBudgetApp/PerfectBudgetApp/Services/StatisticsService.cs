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

        public async Task <IEnumerable<ExpenseStatsViewModel>>  GetAllExpensesBydates(string userId)
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


    }
}
