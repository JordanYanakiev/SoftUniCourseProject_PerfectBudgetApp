using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models;

namespace PerfectBudgetApp.Contracts
{
    public interface IBudgetService
    {
        Task AddNewBudget(AddBudgetViewModel addBudgetViewModel, string userId);

        Task <IEnumerable<AddBudgetViewModel>> GetAllBudgets(string userId);
    }
}
