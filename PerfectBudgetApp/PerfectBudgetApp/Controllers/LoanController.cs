using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Models.Loans;
using PerfectBudgetApp.Services;
using System.Security.Claims;

namespace PerfectBudgetApp.Controllers
{
    

    public class LoanController : Controller
    {
        LoanService loanService;

        public LoanController(LoanService _loanService)
        {
            loanService = _loanService;
        }


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
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;]
            await loanService.RequestLoanAsync(model, userId);

            return RedirectToAction(nameof(Loans));
        }
    }
}
