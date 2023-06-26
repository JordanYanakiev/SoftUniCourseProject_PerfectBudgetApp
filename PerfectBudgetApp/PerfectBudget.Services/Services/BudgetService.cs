using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp;

namespace PerfectBudgetApp.Services
{
    public class BudgetService : IBudgetService
    {
        public Task<IActionResult> AddNewBudget(AddBudgetViewModel addBudgetViewModel)
        {
            var budget = new Budget()
            {
                Id = addBudgetViewModel.
            };
        }
    }
}
