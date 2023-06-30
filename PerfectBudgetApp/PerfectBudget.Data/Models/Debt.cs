using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    public class Debt
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        public string LoanRequester { get; set; }

        [StringLength(100)]
        public string LoanGiver { get; set; }

        [Required]
        public decimal Amount { get; set; }

    }
}
