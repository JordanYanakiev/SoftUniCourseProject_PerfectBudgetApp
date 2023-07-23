using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Expenses;
using PerfectBudgetApp.Models.Statistics;

namespace PerfectBudgetApp.Contracts
{
    public interface IStatisticsService
    {
        Task <IEnumerable<ExpenseStatsViewModel>> GetAllExpensesLastThirtyDays(string userId);
        Task <IEnumerable<ExpenseStatsViewModel>> GetAllExpensesLastSevenDays(string userId);
        Task <List<object>> GetAllExpenseSortedByCategories(IEnumerable<ExpenseStatsViewModel> expenses);
    }
}
