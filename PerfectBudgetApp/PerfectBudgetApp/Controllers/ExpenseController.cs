using Microsoft.AspNetCore.Mvc;

namespace PerfectBudgetApp.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
