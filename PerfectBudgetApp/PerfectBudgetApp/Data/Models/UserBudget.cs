using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class UserBudget
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [Required]
        public int BudgetId { get; set; }
        [Required]
        [ForeignKey(nameof(BudgetId))]
        public Budget Budget { get; set; }
    }
}
