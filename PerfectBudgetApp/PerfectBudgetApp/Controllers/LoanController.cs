using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Models.Loans;
using System.Security.Claims;

namespace PerfectBudgetApp.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult RequestLoan()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Loans()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestLoan(LoanRequestViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return RedirectToAction(nameof(Loans));
        }
    }
}
