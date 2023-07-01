using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Models.Loans;

namespace PerfectBudgetApp.Services
{
    public class LoanService : ILoanService
    {
        BudgetDbContext budgetDvContext;

        public LoanService(BudgetDbContext _budgetDbContext)
        {
            budgetDvContext = _budgetDbContext;
        }

        public Task RequestLoanAsync(LoanRequestViewModel model, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
