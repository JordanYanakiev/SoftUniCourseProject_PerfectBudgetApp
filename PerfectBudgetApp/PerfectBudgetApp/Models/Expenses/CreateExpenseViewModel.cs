using PerfectBudget.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Expenses
{
    public class CreateExpenseViewModel
    {
        [Required]
        public Guid ExpenseId { get; set; }

        [Required]
        public decimal ExpenceAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; } = DateTime.Now;

        [Required]
        [StringLength(ExpenseDescriptionMaxLength, MinimumLength = ExpenseDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public Guid BudgetId { get; set; }
        public IEnumerable<AddBudgetViewModel> Budgets { get; set; } = new List<AddBudgetViewModel>();

        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
