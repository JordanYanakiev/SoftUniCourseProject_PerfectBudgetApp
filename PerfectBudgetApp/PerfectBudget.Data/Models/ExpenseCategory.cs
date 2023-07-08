using PerfectBudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectBudget.Data.Models
{
    public class ExpenseCategory
    {
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        [Required]
        public Guid ExpenseId { get; set; }
        [ForeignKey(nameof(ExpenseId))]
        public Expense Expense { get; set; } = null!;
    }
}
