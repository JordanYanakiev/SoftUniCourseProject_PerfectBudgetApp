
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    public class BudgetExpense
    {
        [Required]
        public Guid ExpenseId { get; set; }

        [Required]
        [ForeignKey(nameof(ExpenseId))]
        public Expense Expense { get; set; }

        [Required]
        public Guid BudgetId { get; set; }

        [Required]
        [ForeignKey(nameof(BudgetId))]
        public Budget Budget { get; set; }
    }
}
