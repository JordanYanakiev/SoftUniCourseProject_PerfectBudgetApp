using PerfectBudgetApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Loans
{
    public class ApproveLoanViewModel
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
        public string LoanGiverNickName { get; set; } = null!;

        public IEnumerable<Budget> Budgets { get; set; }


    }
}
