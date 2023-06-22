using Microsoft.AspNetCore.Identity;

namespace PerfectBudgetApp.Data.Models
{
    public class UserDebt
    {
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int DebtId { get; set; }
        public Debt Debt { get; set; }
    }
}
