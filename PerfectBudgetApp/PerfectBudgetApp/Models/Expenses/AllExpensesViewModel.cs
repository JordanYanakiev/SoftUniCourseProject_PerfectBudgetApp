using PerfectBudgetApp.Contracts;

namespace PerfectBudgetApp.Models.Expenses
{
    public class AllExpensesViewModel
    {
        private readonly IExpenseService expenseService;

        public AllExpensesViewModel(IExpenseService _expenseService)
        {
            expenseService = _expenseService;       
        }

    }
}
