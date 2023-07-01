using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Models.Loans;

namespace PerfectBudgetApp.Contracts
{
    public interface ILoanService
    {
        Task RequestLoanAsync(LoanRequestViewModel model, string userId);
    }
}
