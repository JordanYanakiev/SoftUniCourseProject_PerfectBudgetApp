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


        public string LoanTakerId { get; set; }
    }
}
