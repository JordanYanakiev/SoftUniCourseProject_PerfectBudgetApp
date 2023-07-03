using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Loans;

namespace PerfectBudgetApp.Contracts
{
    public interface ILoanService
    {
        Task RequestLoanAsync(LoanRequestViewModel model, string userId);
        Task<IEnumerable<LoanRequestViewModel>> GetAllLoansAsync();
        Task<ApproveLoanViewModel> GetLoan(Guid loanId, string userId);
        Task ApproveLoanAsync(ApproveLoanViewModel model, string userId);

    }
}
