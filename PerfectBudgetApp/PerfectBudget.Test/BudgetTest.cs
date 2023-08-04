using Moq;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectBudget.Test
{
    [TestFixture]
    public class BudgetTest
    {
        [Test] public void CreateBudgetTest()
        {
            var mockBudgetDb = new Mock<BudgetDbContext>();

            var budget = new BudgetService();

        }


    }
}
