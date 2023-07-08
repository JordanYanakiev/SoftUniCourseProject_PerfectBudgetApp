using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Contracts
{
    public interface IExpenseService
    {
        Task <IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
