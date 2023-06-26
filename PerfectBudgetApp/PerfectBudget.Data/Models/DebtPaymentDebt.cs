
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class DebtPaymentDebt
    {
        [Key]
        public Guid DebtId { get; set; }
        [Required]
        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; }
        [Required]
        public Guid DebtInstallmentId { get; set; }
        [Required]
        [ForeignKey(nameof(DebtInstallmentId))]
        public DebtPayment DeptPayment { get; set; }
    }
}
