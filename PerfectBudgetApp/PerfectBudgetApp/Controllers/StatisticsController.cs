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
        public async Task<List<object>> GetLastThirtyDays()
        {           
            string userId = GetUserId();
            StatisticsViewModel model = new StatisticsViewModel();
            var expensesLastThirtyDays = await statisticsService.GetAllExpensesLastThirtyDays(userId);
            model.CostsLastThirtyDays = await statisticsService.GetAllExpenseSortedByCategories(expensesLastThirtyDays);
            return model.CostsLastThirtyDays;
        }


        [HttpPost]
        public async Task<List<object>> GetLastSevenDays()
        {           
            string userId = GetUserId();
            StatisticsViewModel model = new StatisticsViewModel();
            var expensesLastThirtyDays = await statisticsService.GetAllExpensesLastSevenDays(userId);
            model.CostsLastSevenDays = await statisticsService.GetAllExpenseSortedByCategories(expensesLastThirtyDays);
            return model.CostsLastSevenDays;
        }




        public async Task<IActionResult> Statistics()
        {
            return View();
        }
    }
}
