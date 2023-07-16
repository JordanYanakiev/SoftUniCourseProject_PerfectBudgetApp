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


        public async Task<IActionResult> Statistics()
        {
            string userId = GetUserId();
            StatisticsViewModel model = new StatisticsViewModel();
            model.CategoriesList = await statisticsService.GetAllExpensesBydates(userId);
            return View(model);
        }
    }
}
