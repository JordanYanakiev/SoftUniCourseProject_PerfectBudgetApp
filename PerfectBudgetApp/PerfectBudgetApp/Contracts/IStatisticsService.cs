﻿using PerfectBudgetApp.Data.Models;
using PerfectBudgetApp.Models.Expenses;
using PerfectBudgetApp.Models.Statistics;

namespace PerfectBudgetApp.Contracts
{
    public interface IStatisticsService
    {
        Task <IEnumerable<ExpenseStatsViewModel>> GetAllExpensesBydates(string userId);
        Task <Dictionary<string, decimal>> GetAllExpenseSortedByCategories(IEnumerable<ExpenseStatsViewModel> expenses);
    }
}
