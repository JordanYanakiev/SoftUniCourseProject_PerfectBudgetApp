using Microsoft.AspNetCore.Mvc;
using PerfectBudgetApp.Models;
using System.Diagnostics;

namespace PerfectBudgetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public List<object> GetTotalOrder()
        {
            List<object> result = new List<object>();
            List<string> labels = new List<string> { "test1", "test2", "test3" };
            List<decimal> values = new List<decimal> { 12m, 23m, 3m };
            result.Add(labels);
            result.Add(values);
            return result;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}