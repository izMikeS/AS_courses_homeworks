using OnlineStore.BL.Enums;
using OnlineStore.BL.Models.Entities;
using OnlineStore.BL.Models.Reports;
using System;
using System.Linq;

namespace OnlineStore.BL.ReportGenerators
{
    public class CommonReportGenerator : ReportGeneratorBase
    {
        public CommonReport GetReport(ReportTimeType timeSpan, string categoryName)
        {
            var startReportDateTime = ProjectUtils.GetStartReportDateTime(timeSpan);

            var commonReport = new CommonReport
            {
                ReportTime = timeSpan,
                CategoryName = categoryName
            };
            commonReport.Products = GetProductsAtCategoryOrderBySum(startReportDateTime, categoryName);
            commonReport.TotalSalesSum = GetTotalSalesSum(startReportDateTime, categoryName);
            commonReport.TotalSalesSumAtCategory = commonReport.Products.Sum(p => p.SalesSum);
            commonReport.SalesCountAtCategory = (uint)commonReport.Products.Sum(p => p.SalesCount);
         
            return commonReport;
        }
        private decimal GetTotalSalesSum(DateTime startDateTime, string categoryName)
        {
            return _dbContext.ProductAtOrders.Where(p => p.Order.Date > startDateTime
            && p.Order.Status == OrderStatus.Finished.ToString()
            && p.Product.Category.Name == categoryName)
                .Select(p => p.Product.Price * p.Count).DefaultIfEmpty()
                .Sum(p => p);
        }

        private Product[] GetProductsAtCategoryOrderBySum(DateTime startDateTime, string categoryName)
        {
            return _dbContext.ProductAtOrders.Where(p => p.Order.Date > startDateTime
            && p.Order.Status == OrderStatus.Finished.ToString()
            && p.Product.Category.Name == categoryName)
                .GroupBy(p => p.Product.Name)
                .Select(p =>
                    new Product
                    {
                        Name = p.Key,
                        ManafacturerName = p.FirstOrDefault().Product.Manufacturer.Name,
                        SalesCount = p.Sum(pr => pr.Product.ProductAtOrders.Count),
                        SalesSum = p.Sum(pr => pr.Product.Price * pr.Count)
                    })
                .OrderByDescending(p => p.SalesSum)
                .ToArray();
        }
    }
}
