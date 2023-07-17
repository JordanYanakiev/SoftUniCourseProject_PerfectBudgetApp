using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Statistics
{
    public class ExpenseStatsViewModel
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

        [Required]
        public string CategoryName { get; set; } = null!;

    }
}
