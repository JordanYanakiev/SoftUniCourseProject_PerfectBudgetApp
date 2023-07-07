using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Loans;
using System.Linq;
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

            var allApprovedloans = await budgetDbContext.DebtsIssuers
                .Select(x => new DebtIssuer
                {
                    DebtId = x.DebtId,
                    Debt = x.Debt,
                    DebtIssuerId = x.DebtIssuerId,
                    UserId = x.UserId
                }).ToListAsync();

            int counter = 0;

            for(int i = 0; i < allLoans.Count; i++)
            {
                if (allApprovedloans.Any(x => x.DebtId == allLoans[i].Id))
                {
                    allLoans.Remove(allLoans[i]);
                    i = -1;
                }
            }

            await budgetDbContext.SaveChangesAsync();

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
                            .Select(x => new AddBudgetViewModel()
                            {
                                Id = x.BudgetId,
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
            var debt = await budgetDbContext.Debts
                 .FirstOrDefaultAsync(x => x.Id == model.Id);

            decimal releasedAmount = model.ReleasedAmount;

            if (debt != null)
            {
                debt.LoanGiver = model.LoanGiverNickName;
            }

            var debtsReceiver = await budgetDbContext.DebtsReceivers
                .FirstOrDefaultAsync(x => x.DebtId == model.Id);

            var loanGiverBudget = await budgetDbContext.Budgets
                         .FirstOrDefaultAsync(b => b.Id == model.BudgetId);
            

            //TO DO: Find the budget with the most money check if the amount there is suficient
            //and deduct the amount from it


            var debtIssuer = new DebtIssuer()
            {
                DebtId = model.Id,
                Debt = debt,
                DebtIssuerId = userId,
                UserId = await budgetDbContext.Users
                         .FirstOrDefaultAsync(x => x.Id == userId)
            };

            var allDebtRequesterBudgets = await budgetDbContext.UsersBudgets
                                        .Where(x => x.UserId == debtsReceiver.DebtReceiverId)
                                        .Select(x => new
                                        {
                                            User = x.User,
                                            UserId = x.UserId,
                                            Budget = x.Budget,
                                            BudgetId = x.BudgetId 
                                        })
                                        .OrderBy(x => x.Budget.Amount)
                                        .ToListAsync();

            allDebtRequesterBudgets.OrderByDescending(x => x.Budget.Amount);

            allDebtRequesterBudgets[0].Budget.Amount += model.ReleasedAmount;
            loanGiverBudget.Amount -= model.ReleasedAmount;


            await budgetDbContext.DebtsIssuers.AddAsync(debtIssuer);
            await budgetDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<AddBudgetViewModel>> GetAllBudgetsForLoanRequest(LoanRequestViewModel model)
        {
            //Get list of users' budgets
            var list = await budgetDbContext.UsersBudgets
                            .Where(x => x.UserId == model.LoanTakerId)
                            .Select(x => new AddBudgetViewModel()
                            {
                                Name = x.Budget.Name,
                                Amount = x.Budget.Amount
                            })
                            .ToListAsync();

            return list;
        }
        public async Task<IEnumerable<AddBudgetViewModel>> GetAllBudgetsForLoanRequest2(ApproveLoanViewModel model, string userId)
        {
            //Get list of users' budgets
            var list = await budgetDbContext.UsersBudgets
                            .Where(x => x.UserId == userId)
                            .Select(x => new AddBudgetViewModel()
                            {
                                Name = x.Budget.Name,
                                Amount = x.Budget.Amount
                            })
                            .ToListAsync();

            return list;
        }

        public async Task DeleteLoanAsync(Guid modelId, string userId)
        {

            var debtLoanTaker = await budgetDbContext.DebtsReceivers
                                .FirstOrDefaultAsync(x => x.DebtId == modelId);

            var debt = await budgetDbContext.Debts
                                .FirstOrDefaultAsync(x => x.Id == modelId);

            budgetDbContext.Debts.Remove(debt);
            budgetDbContext.DebtsReceivers.Remove(debtLoanTaker);
            budgetDbContext.SaveChanges();
        }
    }
}
