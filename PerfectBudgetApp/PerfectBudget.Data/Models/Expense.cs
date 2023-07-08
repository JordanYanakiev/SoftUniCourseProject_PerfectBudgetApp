
using PerfectBudget.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerfectBudgetApp.Data.Models
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }        
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateOfIssuedExpense { get; set; }
        public IEnumerable<UserExpense> BudgetsExpenses { get;set; } = new List<UserExpense>();






        //[Required]
        //[MaxLength(35)]
        //public string Name { get; set; } = null!;
        ////[Required]
        ////public int CategoryId { get; set; }
        ////[ForeignKey(nameof(CategoryId))]
        ////public Category Category { get; set; } = null!;
    }
}
