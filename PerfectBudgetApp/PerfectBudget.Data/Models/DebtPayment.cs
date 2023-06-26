using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    public class DebtPayment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public decimal CreditInstallment { get; set; }
    }
}
