using Microsoft.EntityFrameworkCore;
using Moq;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
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
        private IBudgetService budgetService;
        Mock mockBudgetDb;

        [SetUp] 
        public void SetUp() 
        {
            mockBudgetDb = new Mock<BudgetDbContext>();
            mockBudgetDb.Setup(x => x.)
            budgetService = new BudgetService(mockBudgetDb);

            var budget = new Budget()
            {
                Id = Guid.NewGuid(),
                Name = "TestBudget",
                Amount = 250000
            };


            var userBudget = new UserBudget()
            {
                UserId = "00020000 - 0230 - 1234 - 5678 - 123000000000",
                BudgetId = Guid.NewGuid(),
                User = new User()
                {
                    Id = "00020000 - 0230 - 1234 - 5678 - 123000000000",
                    NormalizedUserName = "Coco Maroko"
                },
                Budget = budget
            };
        }

        [Test] 
        public void CreateBudgetTest()
        {
            mockBudgetDb.Setup(x => x.CreateBudget());




        }


    }
}
