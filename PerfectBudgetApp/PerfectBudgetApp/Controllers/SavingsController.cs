using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Models.Savings;

namespace PerfectBudgetApp.Controllers
{
    public class SavingsController : BaseController
    {
        private readonly ISavingsService service;

        public SavingsController(ISavingsService _service)
        {
            service = _service;
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
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSaving(AddNewSavingViewModel model)
        {
            string userId = GetUserId();
            await service.CreateNewSavingAsync(model, userId);
            return RedirectToAction(nameof(Savings));
        }
    }
}
