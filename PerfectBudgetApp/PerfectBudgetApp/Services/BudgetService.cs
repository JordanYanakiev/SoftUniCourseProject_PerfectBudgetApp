using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models;

namespace PerfectBudgetApp.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly BudgetDbContext dbContext;

        public BudgetService(BudgetDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task AddNewBudget(AddBudgetViewModel addBudgetViewModel, string userId)
        {
            var budget = new Budget()
            {
                Id = addBudgetViewModel.Id,
                Name = addBudgetViewModel.Name,
                Amount = addBudgetViewModel.Amount
            };

            var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);

            var userBudget = new UserBudget() { 
                UserId = userId,
                BudgetId = addBudgetViewModel.Id,
                User = user,
                Budget = budget
            };

            await dbContext.Budgets.AddAsync(budget);
            await dbContext.UsersBudgets.AddAsync(userBudget);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddBudgetViewModel>> GetAllBudgets(string userId)
        {
            var budgets = await dbContext.UsersBudgets
                .Include(m => m.Budget)
                .ToListAsync();

            //List<AddBudgetViewModel> addBudgetViewModelList = new List<AddBudgetViewModel>();

            //foreach (var budget in budgets)
            //{
            //    AddBudgetViewModel addBudgetViewModel = new AddBudgetViewModel();
            //    addBudgetViewModel.Id = budget.BudgetId;
            //    addBudgetViewModel.Name = budget.Budget.Name;
            //    addBudgetViewModel.Amount = budget.Budget.Amount;

            //    addBudgetViewModelList.Add(addBudgetViewModel);


            //}

            var modelsList = budgets
               .Select(m => new AddBudgetViewModel()
               {
                   Id = m.BudgetId,
                   Name = m.Budget.Name,
                   Amount = m.Budget.Amount
               });

            return modelsList;

        }
    }
}
