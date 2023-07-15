using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Contracts
{
    public interface IExpenseService
    {
        Task <CreateExpenseViewModel> GetAllCategoriesAsync(string userId);
        Task CreateExpense(CreateExpenseViewModel model, string userId);
        Task EditExpense(CreateExpenseViewModel model, string userId);
        Task<IEnumerable<AllExpensesViewModel>> GetAllExpensesAsync(string userId);
        Task DeleteExpenseAsync(Guid expenseId);
        Task <CreateExpenseViewModel> GetCreateExpenseViewModelAsync(Guid id, string userId);
        Task EditExpense(CreateExpenseViewModel model, Guid id);
        Task <IEnumerable<CategoryViewModel>> GetAllCategories();
        Task <IEnumerable<AddBudgetViewModel>> GetAllBudgets(string userId);
    }
}
