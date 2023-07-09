using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PerfectBudgetApp.Controllers
{
    public class BaseController : Controller
    {
        public string GetUserId()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
