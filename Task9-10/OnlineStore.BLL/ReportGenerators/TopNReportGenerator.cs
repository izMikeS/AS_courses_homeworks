using OnlineStore.BL.Enums;
using OnlineStore.BL.Models.Entities;
using OnlineStore.BL.Models.Reports;
using System.Linq;

namespace OnlineStore.BL.ReportGenerators
{
    public class TopNReportGenerator : ReportGeneratorBase
    {
        public TopNReport GetReport(ReportTimeType timeSpan, int productsCount)
        {
            var startReportDateTime = ProjectUtils.GetStartReportDateTime(timeSpan);
            var topNReport = new TopNReport
            {
                ReportTime = timeSpan,
            };

            topNReport.Products = _dbContext.ProductAtOrders
                .Where(p => p.Order.Date > startReportDateTime
                         && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .OrderByDescending(p => p.Sum(pr => pr.Count))
                .Take(productsCount)
                .Select(p => new ProductForTop
                {
                    ProductName = p.Key,
                    CategoryName = p.FirstOrDefault().Product.Category.Name,
                    SalesCount = p.Sum(pr => pr.Count),
                    SalesSum = p.Sum(pr => pr.Count * pr.Product.Price)
                }).ToArray();
            return topNReport;
        }
    }
}
