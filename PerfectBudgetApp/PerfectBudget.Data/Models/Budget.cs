

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    [Comment("Every budget has custom name")]
    public class Budget
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
        public IEnumerable<Debt> BudgetDebtList { get; set; } = new List<Debt>();
        public IEnumerable<Expense> BudgetExpenseList { get; set; } = new List<Expense>();
        public IEnumerable<BudgetExpense> BudgetsExpenses { get; set; } = new List<BudgetExpense>();
    }
}
