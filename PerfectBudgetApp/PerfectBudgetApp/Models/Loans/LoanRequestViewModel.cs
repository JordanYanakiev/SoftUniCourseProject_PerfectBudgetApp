using System.ComponentModel.DataAnnotations;
using static PerfectBudget.Common.DataConstants;

namespace PerfectBudgetApp.Models.Loans
{
    public class LoanRequestViewModel
    {
        [Required]
        public Guid LoanId { get; set; }

        [Required]
        [StringLength(LoanNameMaxLength, MinimumLength = LoanNameMinLength)]
        public string LoanName { get; set;}

        [Required]
        public decimal RequestedAmount { get; set; }

        [Required]
        [StringLength(LoanAskerNickNameMaxLength, MinimumLength = LoanAskerNickNameMinLength)]
        public string LoanAskerNickName { get; set;}

        [Required]
        public Guid LoanTakerId { get; set; }
    }
}
