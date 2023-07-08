using Microsoft.AspNetCore.Mvc;

namespace PerfectBudgetApp.Controllers
{
    public class ExpenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
