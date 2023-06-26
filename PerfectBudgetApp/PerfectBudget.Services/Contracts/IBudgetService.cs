using Microsoft.AspNetCore.Mvc;

namespace PerfectBudgetApp.Contracts
{
    public interface IBudgetService
    {
        Task<IActionResult> AddNewBudget(AddBudgetViewModel addBudgetViewModel);
    }
}
