using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Savings
{
    public class AddNewSavingViewModel
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public Guid SavingId { get; set; }
        [Required]
        public decimal SavingAmount { get; set; }
        [Required]
        [StringLength(SavingNameMaxLength, MinimumLength = SavingNameMinLength)]
        public string SavingName { get; set; } = null!;
    }
}
