
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

        public async Task DeleteExpenseAsync(Guid expenseId)
        {

            var expenseToDelete = await budgetDbContext.Expenses
                                    .FirstOrDefaultAsync(e => e.Id == expenseId);

            budgetDbContext.Remove(expenseToDelete);
            await budgetDbContext.SaveChangesAsync();
        }

        public Task EditExpense(CreateExpenseViewModel model, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task EditExpense(CreateExpenseViewModel model, Guid id)
        {
            //Get 
            var expenseToEdit = budgetDbContext.Expenses
                .FirstOrDefaultAsync(e => e.Id == id);


            expenseToEdit.Result.Description = model.Description;
            expenseToEdit.Result.Amount = model.ExpenceAmount;
            expenseToEdit.Result.DateOfIssuedExpense = model.DateOfExpense;
            expenseToEdit.Result.BudgetId = model.BudgetId;
            expenseToEdit.Result.CategoryId = model.CategoryId;

            await budgetDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddBudgetViewModel>> GetAllBudgets(string userId)
        {
            var budgets = await budgetDbContext.UsersBudgets
                 .Where(b => b.UserId == userId)
                 .Select(b => new AddBudgetViewModel()
                 {
                     Id = b.BudgetId,
                     Name = b.Budget.Name,
                     Amount = b.Budget.Amount
                 }).ToListAsync();


            return budgets;
        }

        public async Task <IEnumerable<CategoryViewModel>> GetAllCategories()
        {

            var categories = await budgetDbContext.Categories
                            .Select(c => new CategoryViewModel()
                            {
                                Id = c.Id,
                                CategoryName = c.Name
                            }).ToListAsync();

            return categories;
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
                                  DateOfExpense = e.Expense.DateOfIssuedExpense.Date,
                                  Description = e.Expense.Description
                              }).ToListAsync();
            var allExpensesSorted = allExpenses.OrderByDescending(e => e.DateOfExpense);

            return allExpensesSorted;
        }

        public async Task <CreateExpenseViewModel> GetCreateExpenseViewModelAsync(Guid id, string userId)
        {
            var expenseToEdit = budgetDbContext.Expenses
                                .FirstOrDefault(e => e.Id == id);

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

            var expenseViewModel = new CreateExpenseViewModel() 
            {
                ExpenseId = expenseToEdit.Id,
                ExpenceAmount = expenseToEdit.Amount,
                DateOfExpense = expenseToEdit.DateOfIssuedExpense,
                Description = expenseToEdit.Description,
                BudgetId = expenseToEdit.BudgetId,
                CategoryId = expenseToEdit.CategoryId,
                Categories = categories,
                Budgets = budgets
            };

            return expenseViewModel;
        }


    }
}
