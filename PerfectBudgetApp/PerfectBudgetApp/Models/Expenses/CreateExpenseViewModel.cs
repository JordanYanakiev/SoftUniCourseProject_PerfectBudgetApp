using PerfectBudget.Data.Models;
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
        public Category Category { get; set; } = null!;

        [Required]
        public DateTime DateOfExpense { get; set; }
    }
}
