using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Models
{
    public class EditBudgetViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
    }
}
