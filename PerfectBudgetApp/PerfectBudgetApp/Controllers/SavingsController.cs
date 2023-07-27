using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Models.Savings;

namespace PerfectBudgetApp.Controllers
{
    public class SavingsController : BaseController
    {
        private readonly ISavingsService service;
        private readonly IExpenseService expenseService;

        public SavingsController(ISavingsService _service, IExpenseService _expenseService)
        {
            service = _service;
            expenseService = _expenseService;
        }

        public async Task<IActionResult> Savings()
        {
            var model = await service.GetAllSavingsAsync(GetUserId());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddSaving()
        {
            AddNewSavingViewModel model = new AddNewSavingViewModel();
            model.Budgets = await expenseService.GetAllBudgets(GetUserId());


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSaving(AddNewSavingViewModel model)
        {
            string userId = GetUserId();
            await service.CreateNewSavingAsync(model, userId);
            return RedirectToAction(nameof(Savings));
        }

        [HttpGet]
        public async Task<IActionResult> AddMoreMoney(Guid id)
        {
            AddMoreMoneyViewModel model = await service.AddMoreMoneyAsync(id, GetUserId());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMoreMoney(AddMoreMoneyViewModel model, Guid id)
        {
            await service.AddMoreMoney(model, GetUserId(), id);

            return RedirectToAction(nameof(Savings));
        }



        [HttpGet]
        public async Task<IActionResult> TransferMoneyToBudget(Guid savingId)
        {

            return View();
        }
    }
}
