
using Microsoft.EntityFrameworkCore;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Models.Expenses;

namespace PerfectBudgetApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly BudgetDbContext budgetDbContext;

        public ExpenseService(BudgetDbContext _budgetDbContext)
        {
            budgetDbContext = _budgetDbContext;
        }

        //Create new expense
        public async Task CreateExpense(CreateExpenseViewModel model, string userId)
        {
            //Create new expense
            var expense = new Expense()
            {
                Id = Guid.NewGuid(),
                CategoryId = model.CategoryId,
                Amount = model.ExpenceAmount,
                DateOfIssuedExpense = model.DateOfExpense,
                BudgetId = model.BudgetId,
                Description = model.Description,
                Budget = await budgetDbContext.Budgets.FirstOrDefaultAsync(b => b.Id == model.BudgetId),
                Category = await budgetDbContext.Categories.FirstOrDefaultAsync(c => c.Id == model.CategoryId)
            };

            //Create new record for UsersExpenses
            var userExpense = new UserExpense()
            {
                UserId = userId,
                User = await budgetDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId),
                Expense = expense,
                ExpenseId = expense.Id
            };

            //Update budget with the amount of the expense
            var budget = budgetDbContext.Budgets.FirstOrDefault(b => b.Id == expense.BudgetId);
            budget.Amount -= model.ExpenceAmount;

            //Update database
            budgetDbContext.Expenses.Add(expense);
            budgetDbContext.UsersExpenses.Add(userExpense);
            budgetDbContext.Budgets.Update(budget);
            budgetDbContext.SaveChanges();        
        }

        //Get all budgets for the current user and all categories for the expenses
        public async Task <CreateExpenseViewModel> GetAllCategoriesAsync(string userId)
        {
            var categories = budgetDbContext.Categories
                            .Select(c => new CategoryViewModel()
                            {
                                Id = c.Id,
                                CategoryName = c.Name
                            }).ToList();

            var budgets = await budgetDbContext.UsersBudgets
                          .Where(x => x.UserId == userId)
                          .Select(b => new AddBudgetViewModel()
                          {
                              Id = b.BudgetId,
                              Name = b.Budget.Name,
                              Amount = b.Budget.Amount
                          }).ToListAsync();

            var model = new CreateExpenseViewModel()
            {
                Categories = categories,
                Budgets = budgets
            };

            return model;
        }

        //Get all expenses for the main page with expenses
        public async Task<IEnumerable<AllExpensesViewModel>> GetAllExpensesAsync(string userId)
        {

            var allExpenses = await budgetDbContext.UsersExpenses
                              .Where(e => e.UserId == userId)
                              .Select(e => new AllExpensesViewModel()
                              {
                                  ExpenseId = e.ExpenseId,
                                  Amount = e.Expense.Amount,
                                  Category = e.Expense.Category.Name,
                                  DateOfExpense = e.Expense.DateOfIssuedExpense,
                                  Description = e.Expense.Description
                              }).ToListAsync();
            var allExpensesSorted = allExpenses.OrderByDescending(e => e.DateOfExpense);

            return allExpensesSorted;
        }
    }
}
