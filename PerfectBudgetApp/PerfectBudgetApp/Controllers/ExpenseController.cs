using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
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


        public async Task<IActionResult> CreateExpense()
        {
            CreateExpenseViewModel model = await expenseService.GetAllCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseViewModel model)
        {
            string userId = GetUserId();


            return RedirectToAction(nameof(AllExpenses));
        }


    }
}
