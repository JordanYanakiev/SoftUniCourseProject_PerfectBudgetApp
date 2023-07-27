using PerfectBudgetApp.Models.Savings;

namespace PerfectBudgetApp.Contracts
{
    public interface ISavingsService
    {
        Task CreateNewSavingAsync(AddNewSavingViewModel model, string userId);
        Task <IEnumerable<AddNewSavingViewModel>> GetAllSavingsAsync(string userId);
        Task<AddMoreMoneyViewModel> AddMoreMoneyAsync(Guid savingId, string userId);
        Task AddMoreMoney(AddMoreMoneyViewModel model, string userId, Guid id);




    }
}
