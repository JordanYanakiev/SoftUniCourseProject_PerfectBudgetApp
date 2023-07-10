using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService expenseService;

        public ExpenseController(IExpenseService _expenseService)
        {
            expenseService = _expenseService;
        }




        public IActionResult AllExpenses()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateExpense()
        {
            string userId = GetUserId();
            CreateExpenseViewModel model = await expenseService.GetAllCategoriesAsync(userId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseViewModel model)
        {
            string userId = GetUserId();

            await expenseService.CreateExpense(model, userId);
            




            return RedirectToAction(nameof(AllExpenses));
        }


    }
}
