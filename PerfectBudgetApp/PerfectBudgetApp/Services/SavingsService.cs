using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
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


            dbContext.Savings.Add(saving);
            dbContext.UsersSavings.Add(userSaving);
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
                    SavingId = s.Saving.Id
                }).ToListAsync();

            var allSavings2 = await dbContext.UsersSavings
               .Where(x => x.UserId == userId)
               .Select(s => new AddNewSavingViewModel()
               {
                   UserId = s.UserId,
                   SavingAmount = s.Saving.Amount,
                   SavingId = s.Saving.Id
               }).ToListAsync();
            return allSavings;
        }
    }
}
