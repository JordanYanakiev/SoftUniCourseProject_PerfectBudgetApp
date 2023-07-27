using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Savings;

namespace PerfectBudgetApp.Services
{
    public class SavingsService : ISavingsService
    {
        private readonly BudgetDbContext dbContext;
  
        public SavingsService(BudgetDbContext _dbContext)
        {
            dbContext = _dbContext;
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
