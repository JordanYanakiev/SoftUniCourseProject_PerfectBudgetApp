using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;

namespace PerfectBudgetApp.Contracts
{
    public interface IBudgetService
    {
        Task AddNewBudget(AddBudgetViewModel addBudgetViewModel, string userId);

        Task <IEnumerable<AddBudgetViewModel>> GetAllBudgets(string userId);
        Task <EditBudgetViewModel> GetEditBudgetViewModel(Guid budgetId, string userId);
        Task EditBudget(EditBudgetViewModel editBudgetViewModel, Guid budgetId, string userId);
        Task DeleteBudget(Guid budgetId, string userId);
    }
}
