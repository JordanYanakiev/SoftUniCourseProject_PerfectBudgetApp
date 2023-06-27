using Microsoft.AspNetCore.Identity;
using PerfectBudgetApp.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Models
{
    public class EditBudgetViewModel
    {
        public Guid BudgetId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
        public IdentityUser User { get; set; }
        public Budget Budget { get; set; }
    }
}
