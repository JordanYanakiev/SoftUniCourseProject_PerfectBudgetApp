using Microsoft.AspNetCore.Identity;

namespace PerfectBudgetApp.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Debt> Debts { get; set; } = new List<Debt>();
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
