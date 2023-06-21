using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PerfectBudgetApp.Data
{
    public class BudgetDbContext : IdentityDbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
            : base(options)
        {
        }
    }
}