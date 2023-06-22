using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class BudgetExpense
    {
        [Required]
        public int ExpenseId { get; set; }

        [Required]
        [ForeignKey(nameof(ExpenseId))]
        public Expense Expense { get; set; }

        [Required]
        public int BudgetId { get; set; }

        [Required]
        [ForeignKey(nameof(BudgetId))]
        public Budget Budget { get; set; }
    }
}
