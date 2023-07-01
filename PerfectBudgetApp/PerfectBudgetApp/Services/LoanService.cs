using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;

namespace PerfectBudgetApp.Services
{
    public class LoanService : ILoanService
    {
        BudgetDbContext budgetDvContext;

        public LoanService(BudgetDbContext _budgetDbContext)
        {
            budgetDvContext = _budgetDbContext;
        }

    }
}
