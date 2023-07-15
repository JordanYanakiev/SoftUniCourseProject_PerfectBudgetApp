using Microsoft.AspNetCore.Mvc;

namespace PerfectBudgetApp.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
