using PerfectBudgetApp.Models.Savings;

namespace PerfectBudgetApp.Contracts
{
    public interface ISavingsService
    {
        Task CreateNewSavingAsync(AddNewSavingViewModel model, string userId);
        Task <IEnumerable<AddNewSavingViewModel>> GetAllSavingsAsync(string userId);





    }
}
