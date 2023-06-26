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
        [MaxLength(35)]
        public string Giver { get; set; } = null!;
        [Required]
        [MaxLength(35)] 
        public string Taker { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }

    }
}
