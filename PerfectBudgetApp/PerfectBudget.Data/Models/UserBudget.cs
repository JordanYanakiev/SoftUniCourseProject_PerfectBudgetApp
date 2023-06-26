using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public Guid BudgetId { get; set; }
        [Required]
        [ForeignKey(nameof(BudgetId))]
        public Budget Budget { get; set; }
    }
}
