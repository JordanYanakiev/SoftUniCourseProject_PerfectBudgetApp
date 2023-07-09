using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Contracts
{
    public interface IExpenseService
    {
        Task <CreateExpenseViewModel> GetAllCategoriesAsync();

        Task CreateExpense(CreateExpenseViewModel model, string userId);
    }
}
