using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models;
using System.Security.Claims;

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

        public async Task<EditBudgetViewModel> GetEditBudgetViewModel(Guid Id, string userId)
        {
            var budget = await dbContext.UsersBudgets
                .Include(m => m.Budget)
                .FirstOrDefaultAsync(b =>  b.BudgetId == Id);

            var editBudgetViewModel = new EditBudgetViewModel()
            {
                BudgetId = budget.Budget.Id,
                Name = budget.Budget.Name,
                Amount = budget.Budget.Amount
            };
            
            return editBudgetViewModel;
        }

        public async Task EditBudget(EditBudgetViewModel editBudgetViewModel, Guid budgetId, string userId)
        {
            //var budget = new Budget()
            //{
            //    Id = editBudgetViewModel.Id,
            //    Name = editBudgetViewModel.Name,
            //    Amount = editBudgetViewModel.Amount
            //};

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            //var userBudget = await dbContext.UsersBudgets
                //.FirstOrDefaultAsync(u => u.UserId == userId && u.BudgetId == budgetId);     
            
            var userBudget = await dbContext.Budgets
                .FirstOrDefaultAsync(u => u.Id == budgetId);

            var budget = await dbContext.Budgets
                .FirstOrDefaultAsync(u => u.Id == budgetId);

            if (userBudget != null)
            {
                userBudget.Amount = editBudgetViewModel.Amount;
                userBudget.Name = editBudgetViewModel.Name;
            }

            var budgetToSave = new Budget()
            {
                Id = editBudgetViewModel.BudgetId,
                Name = editBudgetViewModel.Name,
                Amount = editBudgetViewModel.Amount
            };

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddBudgetViewModel>> GetAllBudgets(string userId)
        {
            var budgets = await dbContext.UsersBudgets
                .Include(m => m.Budget)
                .Where(m =>  m.UserId == userId )
                .ToListAsync();

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
