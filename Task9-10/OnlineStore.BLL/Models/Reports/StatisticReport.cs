namespace OnlineStore.BL.Models.Reports
{
    public class StatisticReport : ReportBase
    {
        public int WeekSalesCount { get; set; }
        public decimal WeekSalesSum { get; set; }
        public int MonthSalesCount { get; set; }
        public decimal MonthSalesSum { get; set; }
        public int YearSalesCount { get; set; }
        public decimal YearSalesSum { get; set; }
    }
}
