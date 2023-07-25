using Microsoft.AspNetCore.Mvc;

namespace PerfectBudgetApp.Controllers
{
    public class SavingsController : Controller
    {
        public IActionResult Savings()
        {
            return View();
        }
    }
}
