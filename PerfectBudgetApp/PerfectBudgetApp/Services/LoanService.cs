using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Loans;
using System.Security.Claims;

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
            var allLoans = await budgetDbContext.DebtsReceivers
                .Select(x => new LoanRequestViewModel()
                {
                    LoanTakerId = x.DebtReceiverId,
                    Id = x.DebtId,
                    LoanName = x.Debt.Name,
                    LoanAskerNickName = x.Debt.LoanRequester,
                    RequestedAmount = x.Debt.Amount
                }).ToListAsync();

            return allLoans;
        }

        public async Task<ApproveLoanViewModel> GetLoan(Guid loanId, string userId)
        {
            //Get current loan
            var loan = await budgetDbContext.Debts
                                        .FirstOrDefaultAsync(x => x.Id == loanId);

            //Get list of users' budgets
            var list = await budgetDbContext.UsersBudgets
                            .Where(x => x.UserId == userId)
                            .Select(x => new Budget()
                            {
                                Name = x.Budget.Name,
                                Amount = x.Budget.Amount
                            })
                            .ToListAsync();

            var approveLoanViewModel = new ApproveLoanViewModel()
            {
                Id = loan.Id,
                LoanName = loan.Name,
                RequestedAmount = loan.Amount,
                LoanAskerNickName = loan.LoanRequester,
                Budgets = list
            };

            return approveLoanViewModel;
        }

        public async Task ApproveLoanAsync(ApproveLoanViewModel model, string userId)
        {
            //var debt = 



            throw new NotImplementedException();
        }
    }
}
