
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly BudgetDbContext budgetDbContext;

        public ExpenseService(BudgetDbContext _budgetDbContext)
        {
            budgetDbContext = _budgetDbContext;
        }

        public Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {



            throw new NotImplementedException();
        }
    }
}
