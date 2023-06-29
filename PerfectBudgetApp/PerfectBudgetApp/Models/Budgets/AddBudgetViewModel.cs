using PerfectBudgetApp.Data.Models;
using PerfectBudget.Common;
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Models.Budgets
{
    public class AddBudgetViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
    }
}
