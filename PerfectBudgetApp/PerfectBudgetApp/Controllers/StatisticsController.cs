using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Models.Statistics;

namespace PerfectBudgetApp.Controllers
{
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService _statistics)
        {
            statisticsService = _statistics;
        }

        [HttpPost]
        public async Task<List<object>> GetTotalOrder()
        {
            string userId = GetUserId();
            StatisticsViewModel model = new StatisticsViewModel();
            var expenseStats = await statisticsService.GetAllExpensesBydates(userId);
            model.Costs = await statisticsService.GetAllExpenseSortedByCategories(expenseStats);
            return model.Costs;
        }
        public async Task<IActionResult> Statistics()
        {
            return View();
        }
    }
}
