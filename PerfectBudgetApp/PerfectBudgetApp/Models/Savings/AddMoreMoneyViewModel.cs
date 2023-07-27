using PerfectBudgetApp.Models.Budgets;
using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Savings
{
    public class AddMoreMoneyViewModel
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public Guid SavingId { get; set; }
        [Required]
        public decimal SavingAmount { get; set; }
        [Required]
        public decimal AmountToAdd { get; set; }
        [Required]
        [StringLength(SavingNameMaxLength, MinimumLength = SavingNameMinLength)]
        public string SavingName { get; set; } = null!;
        public Guid BudgetId { get; set; }
        public IEnumerable<AddBudgetViewModel> Budgets { get; set; } = new List<AddBudgetViewModel>();
    }
}
