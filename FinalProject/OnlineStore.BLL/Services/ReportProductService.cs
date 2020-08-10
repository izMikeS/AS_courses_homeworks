using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using System;

namespace OnlineStore.BLL.Services
{
    public class ReportProductStatisticService : IReportProductStatisticService
    {
        private readonly IProductAtOrderService _productAtOrderService;
        public ReportProductStatisticService(IProductAtOrderService po)
        {
            _productAtOrderService = po;
        }
        public ProductStatisticReportDto GetReportByProductId(int productId)
        {
            var weekAgoDateTime = DateTime.Now.AddDays(-7);
            var monthAgoDateTime = DateTime.Now.AddMonths(-1);
            var yearAgoDateTime = DateTime.Now.AddYears(-1);

            return new ProductStatisticReportDto
            {
                WeekSalesCount = _productAtOrderService.GetSalesCount(productId, weekAgoDateTime),
                WeekSalesSum = _productAtOrderService.GetSalesSum(productId, weekAgoDateTime),
                MonthSalesCount = _productAtOrderService.GetSalesCount(productId, monthAgoDateTime),
                MonthSalesSum = _productAtOrderService.GetSalesSum(productId, monthAgoDateTime),
                YearSalesCount = _productAtOrderService.GetSalesCount(productId, yearAgoDateTime),
                YearSalesSum = _productAtOrderService.GetSalesSum(productId, yearAgoDateTime),
            };
        }
    }
}
