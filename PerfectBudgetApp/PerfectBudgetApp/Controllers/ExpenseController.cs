using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Expenses;
using PerfectBudgetApp.Services;

namespace PerfectBudgetApp.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService expenseService;

        public ExpenseController(IExpenseService _expenseService)
        {
            expenseService = _expenseService;
        }




        public async Task<IActionResult> AllExpenses()
        {
            string userId = GetUserId();
            IEnumerable<AllExpensesViewModel> model = await expenseService.GetAllExpensesAsync(userId);

            return View(model);
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

        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            await expenseService.DeleteExpenseAsync(id);

            return RedirectToAction(nameof(AllExpenses));
        }

        [HttpGet]
        public async Task<IActionResult> EditExpense(Guid id)
        {
            string userId = GetUserId();
            CreateExpenseViewModel expenseViewModel = await expenseService.GetCreateExpenseViewModelAsync(id, userId);

            return View(expenseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditExpense(CreateExpenseViewModel model, Guid id)
        {
            string userId = GetUserId();
            model.ExpenseId = id;
            model.Categories = await expenseService.GetAllCategories();
            model.Budgets = await expenseService.GetAllBudgets(userId);

            if (ModelState.IsValid)
            {
                await expenseService.EditExpense(model, id);
                return RedirectToAction(nameof(AllExpenses));
            }

            return View(model);
        }
    }
}
