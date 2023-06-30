using Microsoft.AspNetCore.Mvc;

namespace PerfectBudgetApp.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult RequestLoan()
        {
            return View();
        }
        
        public IActionResult Loans()
        {
            return View();
        }
    }
}
