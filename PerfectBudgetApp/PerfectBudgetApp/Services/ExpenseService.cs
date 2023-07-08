
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;

namespace PerfectBudgetApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly BudgetDbContext budgetDbContext;

        public ExpenseService(BudgetDbContext _budgetDbContext)
        {
            budgetDbContext = _budgetDbContext;
        }








    }
}
