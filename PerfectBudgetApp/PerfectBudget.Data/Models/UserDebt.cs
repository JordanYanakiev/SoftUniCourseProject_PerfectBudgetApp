using Microsoft.AspNetCore.Identity;

namespace PerfectBudgetApp.Data.Models
{
    public class UserDebt
    {
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public Guid DebtId { get; set; }
        public Debt Debt { get; set; }
    }
}
