using Microsoft.AspNetCore.Identity;
using PerfectBudget.Data.Models;

namespace PerfectBudgetApp.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Debt> Debts { get; set; } = new List<Debt>();
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
        public IEnumerable<Saving> Savings { get; set; } = new List<Saving>();
    }
}
