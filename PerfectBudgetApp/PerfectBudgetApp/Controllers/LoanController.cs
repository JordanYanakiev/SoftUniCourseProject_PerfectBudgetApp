using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Models.Loans;
using PerfectBudgetApp.Services;
using System.Security.Claims;

namespace PerfectBudgetApp.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService loanService;

        public LoanController(ILoanService _loanService)
        {
            this.loanService = _loanService;
        }


        public IActionResult RequestLoan()
        {
            return View();
        }


        public IActionResult Loans()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RequestLoan(LoanRequestViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await loanService.RequestLoanAsync(model, userId);

            return RedirectToAction(nameof(Loans));
        }
    }
}
