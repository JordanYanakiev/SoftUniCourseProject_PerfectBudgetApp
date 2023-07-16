using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
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

        public async Task <IEnumerable<string>>  GetAllExpensesBydates(string userId)
        {
            //StatisticsViewModel model = new StatisticsViewModel();
            DateTime today = DateTime.Now;
            var expenseCategoriesByDate = await budgetDbContext.UsersExpenses
             .Where(x => x.UserId == userId && x.Expense.DateOfIssuedExpense >= today + TimeSpan.FromDays(-30))
             .Select(e => e.Expense.Category.Name.ToString())
             .ToListAsync();
            //model.CategoriesList = expenseCategoriesByDate;

            return expenseCategoriesByDate;
        }
    }
}
