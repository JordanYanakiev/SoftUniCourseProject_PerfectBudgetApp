using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Loans;
using System.Runtime.Serialization;

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
            Guid replacementGuid = Guid.NewGuid();
            if (model.Id != replacementGuid)
            {
                model.Id = replacementGuid;
            }

            var debt = new Debt()
            {
                Id = model.Id,
                Name = model.LoanName,
                Amount = model.RequestedAmount,
                LoanRequester = model.LoanAskerNickName,
                LoanGiver = "John Doe"
            };


            var loanLoanAsker = new DebtReceiver()
            {
                DebtReceiverId = userId,
                DebtId = model.Id
            };

            await budgetDbContext.DebtsReceivers.AddAsync(loanLoanAsker);
            await budgetDbContext.Debts.AddAsync(debt);
            await budgetDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<LoanRequestViewModel>> GetAllLoansAsync()
        {
            //IEnumerable<LoanRequestViewModel> allLoans;

            var allLoans = await budgetDbContext.Debts
                .Select(x => new LoanRequestViewModel()
                {
                    Id = x.Id,
                    LoanName = x.Name,
                    LoanAskerNickName = x.LoanRequester,
                    RequestedAmount = x.Amount,
                }).ToListAsync();

            var allLoans2 = await budgetDbContext.DebtsReceivers
                .Select(x => new LoanRequestViewModel()
                {
                    LoanTakerId = x.DebtReceiverId,
                    Id = x.DebtId,
                    LoanName = x.Debt.Name,
                    LoanAskerNickName = x.Debt.LoanRequester,
                    RequestedAmount = x.Debt.Amount
                }).ToListAsync();

            return allLoans2;
        }

    }
}
