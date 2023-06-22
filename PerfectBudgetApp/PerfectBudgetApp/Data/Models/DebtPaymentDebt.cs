using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class DebtPaymentDebt
    {
        [Required]
        public int DebtId { get; set; }
        [Required]
        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; }
        [Required]
        public int DebtInstallmentId { get; set; }
        [Required]
        [ForeignKey(nameof(DebtInstallmentId))]
        public DebtPayment DeptPayment { get; set; }
    }
}
