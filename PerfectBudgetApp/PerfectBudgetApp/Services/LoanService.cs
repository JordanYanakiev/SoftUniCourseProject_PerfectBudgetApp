using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Loans;

namespace PerfectBudgetApp.Services
{
    public class LoanService : ILoanService
    {
        private readonly BudgetDbContext budgetDbContext;

        public LoanService(BudgetDbContext _budgetDbContext)
        {
            budgetDbContext = _budgetDbContext;
        }


        public async Task RequestLoanAsync(LoanRequestViewModel model, string userId)
        {
            var debt = new Debt()
            {
                Id = new Guid(),
                Name = model.LoanName,
                Amount = model.RequestedAmount,
                LoanRequester = model.LoanAskerNickName
            };

            var loanLoanAsker = new DebtReceiver()
            {
                DebtReceiverId = userId,
                DebtId = model.LoanId
            };

            await budgetDbContext.Debts.AddAsync(debt);
            await budgetDbContext.DebtsReceivers.AddAsync(loanLoanAsker);
            await budgetDbContext.SaveChangesAsync();
        }
    }
}
