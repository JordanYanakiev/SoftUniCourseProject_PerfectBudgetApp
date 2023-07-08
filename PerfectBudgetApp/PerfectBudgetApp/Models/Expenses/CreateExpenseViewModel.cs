using PerfectBudget.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Models.Expenses
{
    public class CreateExpenseViewModel
    {
        [Required]
        public Guid ExpenseId { get; set; }

        [Required]
        public decimal ExpenceAmount { get; set; }

        [Required]
        public DateTime DateOfExpense { get; set; }

        public Guid BudgetId { get; set; }
        public IEnumerable<AddBudgetViewModel> Budgets { get; set; } = new List<AddBudgetViewModel>();

        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
