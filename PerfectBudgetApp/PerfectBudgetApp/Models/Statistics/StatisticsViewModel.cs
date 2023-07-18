namespace PerfectBudgetApp.Models.Statistics
{
    public class StatisticsViewModel
    {
        public IEnumerable<ExpenseStatsViewModel> CategoriesList { get; set; } = new List<ExpenseStatsViewModel>();

        public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
        public IEnumerable<decimal> ExpenseCosts { get; set; } = new List<decimal>();
        public Dictionary<string, decimal> Costs { get; set; } = new Dictionary<string, decimal>();
    }
}
