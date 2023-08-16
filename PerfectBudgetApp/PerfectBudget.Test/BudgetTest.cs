using Microsoft.EntityFrameworkCore;
using Moq;
using PerfectBudgetApp.Contracts;
using PerfectBudgetApp.Data;
using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Budgets;
using PerfectBudgetApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectBudget.Test;
using PerfectBudgetApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PerfectBudget.Test
{
    [TestFixture]
    public class BudgetTest
    {
        private BudgetService budgetService;
        private IBudgetService ibudgetService;
        //Mock mockBudgetDb;
        private Budget budgetSample01;
        private AddBudgetViewModel addBudgetViewModel01;
        private UserBudget testUserBudget01;
        private UserBudget testUserBudget02;
        private BudgetDbContext budgetDbContext01;
        private BudgetController budgetController01;

        public BudgetTest(IBudgetService _budgetService, BudgetDbContext _budgetDbContext01, UserBudget _testUserBudget01, UserBudget _testUserBudget02, BudgetController _budgetController01)
        {
            ibudgetService = _budgetService;
            budgetDbContext01 = _budgetDbContext01;
            testUserBudget01 = _testUserBudget01;
            testUserBudget02 = _testUserBudget02;
            budgetController01 = _budgetController01;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            budgetService = new BudgetService(budgetDbContext01);
            //mockBudgetDb = new Mock<BudgetDbContext>();
            ////budgetService = new BudgetService(mockBudgetDb);

            addBudgetViewModel01 = new AddBudgetViewModel()
            {
                Id = Guid.NewGuid(),
                Name = "TestBudget",
                Amount = 250000
            };

            budgetSample01 = new Budget()
            {
                Id = addBudgetViewModel01.Id,
                Name = "TestBudget",
                Amount = 250000
            };

            testUserBudget01 = new UserBudget()
            {
                UserId = "05580017-67d4-4766-9f1d-3327a26530fd",
                BudgetId = addBudgetViewModel01.Id,
                User = budgetDbContext01.Users.FirstOrDefault(u => u.Id == "05580017-67d4-4766-9f1d-3327a26530fd"),
                Budget = budgetSample01
            };

            testUserBudget02 = new UserBudget()
            {
                UserId = "1c6d2885-57e4-4736-8b96-141a3890d399",
                BudgetId = addBudgetViewModel01.Id,
                User = budgetDbContext01.Users.FirstOrDefault(u => u.Id == "1c6d2885-57e4-4736-8b96-141a3890d399"),
                Budget = budgetSample01
            };



        }

        [Test]
        public void CreateBudgetTest()
        {
            //var result =ibudgetService.AddNewBudget(addBudgetViewModel01, "05580017 - 67d4 - 4766 - 9f1d - 3327a26530fd");

            //Arrange

            //Act: invoke the controller method
            var result = this.budgetController01.AddBudget(addBudgetViewModel01);

            //Assert a view is returned
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

             //Assert an event model is returned
            var resultModel = viewResult.Model as AddBudgetViewModel;
            Assert.IsNotNull(resultModel);
        }
    }
}
