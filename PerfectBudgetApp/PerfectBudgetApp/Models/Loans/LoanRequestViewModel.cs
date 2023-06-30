using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Models.Loans
{
    public class LoanRequestViewModel
    {
        [Required]
        public Guid LoanId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string LoanName { get; set;}

        [Required]
        public decimal RequestedAmount { get; set; }

        [Required]
        public string LoanAskerNickName { get; set;}

        [Required]
        public Guid LoanTakerId { get; set; }
    }
}
