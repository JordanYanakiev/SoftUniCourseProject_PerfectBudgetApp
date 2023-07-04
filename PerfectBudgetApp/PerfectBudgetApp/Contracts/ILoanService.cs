using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Loans;

namespace PerfectBudgetApp.Contracts
{
    public interface ILoanService
    {
        Task<IEnumerable<AddBudgetViewModel>> GetAllBudgetsForLoanRequest(LoanRequestViewModel model);
        Task<IEnumerable<AddBudgetViewModel>> GetAllBudgetsForLoanRequest2(ApproveLoanViewModel model, string userId);
        Task RequestLoanAsync(LoanRequestViewModel model, string userId);
        Task<IEnumerable<LoanRequestViewModel>> GetAllLoansAsync();
        Task<ApproveLoanViewModel> GetLoan(Guid loanId, string userId);
        Task ApproveLoanAsync(ApproveLoanViewModel model, string userId);

    }
}
