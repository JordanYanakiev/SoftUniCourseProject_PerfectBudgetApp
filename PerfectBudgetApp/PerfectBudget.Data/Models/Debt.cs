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
        [Required]
        public decimal Amount { get; set; }

    }
}
