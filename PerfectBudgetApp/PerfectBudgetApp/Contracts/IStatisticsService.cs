using PerfectBudgetApp.Models.Statistics;

namespace PerfectBudgetApp.Contracts
{
    public interface IStatisticsService
    {
        Task <IEnumerable<string>> GetAllExpensesBydates(string userId);
    }
}
