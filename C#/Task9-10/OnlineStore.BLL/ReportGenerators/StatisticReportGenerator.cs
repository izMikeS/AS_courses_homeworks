using OnlineStore.BL.Enums;
using OnlineStore.BL.Models.Reports;
using System.Linq;

namespace OnlineStore.BL.ReportGenerators
{
    public class StatisticReportGenerator : ReportGeneratorBase
    {
        public StatisticReport GetReport(string productName)
        {
            var weekAgoDateTime = ProjectUtils.GetStartReportDateTime(ReportTimeType.Week);
            var monthAgoDateTime = ProjectUtils.GetStartReportDateTime(ReportTimeType.Month);
            var yearAgoDateTime = ProjectUtils.GetStartReportDateTime(ReportTimeType.Year);

            var report = new StatisticReport();

            report.WeekSalesCount = _dbContext.ProductAtOrders.Where(p => p.Product.Name == productName
                                                                    && p.Order.Date > weekAgoDateTime
                                                                    && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count)).DefaultIfEmpty()
                .Sum(p => p);

            report.WeekSalesSum = _dbContext.ProductAtOrders.Where(p => p.Product.Name == productName
                                                        && p.Order.Date > weekAgoDateTime
                                                        && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count * pr.Product.Price)).DefaultIfEmpty()
                .Sum(p => p);

            report.MonthSalesCount = _dbContext.ProductAtOrders.Where(p => p.Product.Name == productName
                                                        && p.Order.Date > monthAgoDateTime
                                                        && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count)).DefaultIfEmpty()
                .Sum(p => p);

            report.MonthSalesSum = _dbContext.ProductAtOrders.Where(p => p.Product.Name == productName
                                                        && p.Order.Date > monthAgoDateTime
                                                        && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count * pr.Product.Price)).DefaultIfEmpty()
                .Sum(p => p);

            report.YearSalesCount = _dbContext.ProductAtOrders.Where(p => p.Product.Name == productName
                                                        && p.Order.Date > yearAgoDateTime
                                                        && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count)).DefaultIfEmpty()
                .Sum(p => p);

            report.YearSalesSum = _dbContext.ProductAtOrders.Where(p => p.Product.Name == productName
                                                        && p.Order.Date > yearAgoDateTime
                                                        && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count * pr.Product.Price)).DefaultIfEmpty()
                .Sum(p => p);

            return report;
        }
    }
}
