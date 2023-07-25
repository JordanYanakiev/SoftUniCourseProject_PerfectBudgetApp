using static PerfectBudget.Common.DataConstants;
using PerfectBudget.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(ExpenseDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public Guid BudgetId { get; set; }

        [ForeignKey(nameof(BudgetId))]
        public Budget Budget { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfIssuedExpense { get; set; }
        //public IEnumerable<UserExpense> BudgetsExpenses { get;set; } = new List<UserExpense>();
    }
}
