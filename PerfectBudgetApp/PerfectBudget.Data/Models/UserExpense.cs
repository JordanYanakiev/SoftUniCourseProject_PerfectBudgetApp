using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    public class UserExpense
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [Required]
        public Guid ExpenseId { get; set; }
        [Required]
        [ForeignKey(nameof(ExpenseId))]
        public Expense Expense { get; set; }
    }
}
