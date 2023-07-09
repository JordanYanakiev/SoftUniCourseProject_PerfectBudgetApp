
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
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

        public Task CreateExpense(CreateExpenseViewModel model, string userId)
        {
            var expense = new Expense()
            {
                Id = new Guid(),
                CategoryId = model.CategoryId
                
                //TO DO: create dropdown menu for Budgets in CreateExpenseViewModel!!!!!!!

            };
            throw new NotImplementedException();
        }

        public async Task <CreateExpenseViewModel> GetAllCategoriesAsync()
        {
            var categories = budgetDbContext.Categories
                            .Select(c => new CategoryViewModel()
                            {
                                CategoryName = c.Name
                            }).ToList();

            var model = new CreateExpenseViewModel()
            {
                Categories = categories
            };

            return model;
        }


    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
