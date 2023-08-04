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
        private BudgetService budgetService;

        [SetUp] 
        public void SetUp() 
        {
            var mockBudgetDb = new Mock<BudgetDbContext>();
            budgetService = new BudgetService(mockBudgetDb.Object);
        }

        [Test] public void CreateBudgetTest()
        {
            


        }


    }
}
