
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateOfIssuedExpense { get; set; }

        public IEnumerable<BudgetExpense> BudgetsExpenses { get;set; } = new List<BudgetExpense>();
    }
}
