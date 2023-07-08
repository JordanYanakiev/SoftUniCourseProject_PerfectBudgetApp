using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;

namespace PerfectBudgetApp.Controllers
{
    public class ExpenseController : Controller
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
    }
}
