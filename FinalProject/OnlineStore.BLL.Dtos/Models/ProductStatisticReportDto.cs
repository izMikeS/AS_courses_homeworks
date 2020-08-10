namespace OnlineStore.BLL.Dtos.Models
{
    public class ProductStatisticReportDto
    {
        public uint WeekSalesCount { get; set; }
        public decimal WeekSalesSum { get; set; }
        public uint MonthSalesCount { get; set; }
        public decimal MonthSalesSum { get; set; }
        public uint YearSalesCount { get; set; }
        public decimal YearSalesSum { get; set; }
    }
}
