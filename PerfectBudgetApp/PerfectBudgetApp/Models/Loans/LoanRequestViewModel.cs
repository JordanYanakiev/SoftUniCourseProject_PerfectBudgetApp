using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Loans
{
    public class LoanRequestViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(LoanNameMaxLength, MinimumLength = LoanNameMinLength)]
        public string LoanName { get; set; } = null!;
        [Required]
        public decimal RequestedAmount { get; set; }
        [Required]
        [StringLength(LoanAskerNickNameMaxLength, MinimumLength = LoanAskerNickNameMinLength)]
        public string LoanAskerNickName { get; set; } = null!;

        public Guid BudgetId { get; set; }
        public IEnumerable<AddBudgetViewModel> Budgets { get; set; } = new List<AddBudgetViewModel>();

        public string LoanTakerId { get; set; }
    }
}
