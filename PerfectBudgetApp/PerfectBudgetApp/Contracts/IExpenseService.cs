using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Contracts
{
    public interface IExpenseService
    {
        Task <CreateExpenseViewModel> GetAllCategoriesAsync(string userId);

        Task CreateExpense(CreateExpenseViewModel model, string userId);
    }
}
