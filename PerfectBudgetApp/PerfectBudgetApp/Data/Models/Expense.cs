
using System.ComponentModel.DataAnnotations;

namespace PerfectBudgetApp.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateOfIssuedExpense { get; set; }
    }
}
