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



        public async Task<IActionResult> Loans()
        {
            IEnumerable<LoanRequestViewModel> allLoans = await loanService.GetAllLoansAsync();
            return View(allLoans);
        }

        public IActionResult RequestLoan()
        {
            LoanRequestViewModel model = new LoanRequestViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RequestLoan(LoanRequestViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await loanService.RequestLoanAsync(model, userId);

            return RedirectToAction(nameof(Loans));
        }

        public async Task<IActionResult> ApproveLoan(Guid id)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await loanService.GetLoan(id, userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveLoan(ApproveLoanViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //var model = await loanService.GetLoan(id, userId);
            await loanService.ApproveLoanAsync(model, userId);

            return View(model);
        }


    }
}
