using Microsoft.Build.Framework;
using PerfectBudget.Data.Models;
using PerfectBudgetApp.Contracts;

namespace PerfectBudgetApp.Models.Expenses
{
    public class AllExpensesViewModel
    {
        [Required]
        public Guid ExpenseId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public DateTime DateOfExpense { get; set; }
    }
}
