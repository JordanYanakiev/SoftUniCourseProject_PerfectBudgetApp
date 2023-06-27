﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models;
using System.Security.Claims;

namespace PerfectBudgetApp.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetService budgetService;

        public BudgetController(IBudgetService _budgetService)
        {
            this.budgetService = _budgetService;
        }


        public async Task<IActionResult> Budget()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await budgetService.GetAllBudgets(userId);

            return View(model);
        }

        public IActionResult AddBudget()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBudget(AddBudgetViewModel model)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await budgetService.AddNewBudget(model, userId);

            return RedirectToAction(nameof(Budget));
        }

        [HttpGet]
        public async Task<IActionResult> EditBudget(Guid id)
        {
            string userId =  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            EditBudgetViewModel editBudgetModel = await budgetService.GetEditBudgetViewModel(id, userId);
            EditBudgetViewModel editBudgetModel2 = await budgetService.GetEditBudgetViewModel(id, userId);

            return View(editBudgetModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditBudget(Guid id, EditBudgetViewModel editBudgetModel)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //EditBudgetViewModel editBudgetModel = await budgetService.GetEditBudgetViewModel(id, userId);
            if (ModelState.IsValid)
            {
                await budgetService.EditBudget(editBudgetModel, id, userId);
            }

            return RedirectToAction(nameof(Budget));
        }

    }
}
