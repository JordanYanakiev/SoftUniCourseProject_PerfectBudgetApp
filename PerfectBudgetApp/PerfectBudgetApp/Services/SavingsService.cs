using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Savings;
using System.Xml.Linq;

namespace PerfectBudgetApp.Services
{
    public class SavingsService : ISavingsService
    {
        private readonly BudgetDbContext dbContext;
  
        public SavingsService(BudgetDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task AddMoreMoney(AddMoreMoneyViewModel model, string userId, Guid id)
        {
            var saving = new Saving()
            {
                Id = id,
                Name = model.SavingName,
                Amount = model.SavingAmount + model.AmountToAdd
            };

            var budget = await dbContext.Budgets.FirstOrDefaultAsync(b => b.Id == model.BudgetId);
            budget.Amount -= model.AmountToAdd;

            dbContext.Budgets.Update(budget);
            dbContext.Savings.Update(saving);
            await dbContext.SaveChangesAsync(); 
        }

        public async Task<AddMoreMoneyViewModel> AddMoreMoneyAsync(Guid savingId, string userId)
        {
            var saving = await dbContext.Savings
                .FirstOrDefaultAsync(s => s.Id == savingId);

            var addMoreMoney = new AddMoreMoneyViewModel();
            addMoreMoney.SavingAmount = saving.Amount;
            addMoreMoney.SavingName = saving.Name;
            addMoreMoney.SavingId = savingId;
            addMoreMoney.Budgets = await dbContext.UsersBudgets
                .Where(b => b.UserId == userId)
                .Select(b => new AddBudgetViewModel()
                {
                    Id = b.BudgetId,
                    Name = b.Budget.Name,
                    Amount = b.Budget.Amount
                }).ToListAsync();
            return addMoreMoney;
        }

        public async Task CreateNewSavingAsync(AddNewSavingViewModel model, string userId)
        {
            Guid replacementGuid = Guid.NewGuid();
            if (model.SavingId != replacementGuid)
            {
                model.SavingId = replacementGuid;
            }

            var saving = new Saving()
            {
                Id = model.SavingId,
                Name = model.SavingName,
                Amount = model.SavingAmount
            };

            var userSaving = new UserSaving()
            {
                UserId = userId,
                SavingsId = saving.Id
            };

            var budget = await dbContext.Budgets
                          .FirstOrDefaultAsync(x => x.Id == model.BudgetId);
            budget.Amount -= model.SavingAmount;

            dbContext.Savings.Add(saving);
            dbContext.UsersSavings.Add(userSaving);
            dbContext.Budgets.Update(budget);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddNewSavingViewModel>> GetAllSavingsAsync(string userId)
        {
            var allSavings = await dbContext.UsersSavings
                .Where(x => x.UserId == userId)
                .Select(s => new AddNewSavingViewModel()
                {
                    UserId = s.UserId,
                    SavingAmount = s.Saving.Amount,
                    SavingId = s.Saving.Id,
                    SavingName = s.Saving.Name
                }).ToListAsync();


            return allSavings;
        }
    }
}
