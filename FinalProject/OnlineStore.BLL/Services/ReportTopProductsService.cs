using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;

namespace OnlineStore.BLL.Services
{
    public class ReportTopProductsService : IReportTopProductsService
    {
        IProductAtOrderService _productAtOrderService;
        public ReportTopProductsService(IProductAtOrderService po)
        {
            _productAtOrderService = po;
        }
        public TopProductsReportDto GetReport(ReportTimeType timeSpan, int page = 1, int countAtPage = 10)
        {
            var startReportDateTime = ProjectUtils.GetStartReportDateTime(timeSpan);
            var report = new TopProductsReportDto
            {
                ReportTime = timeSpan
            };

            report.Products = _productAtOrderService.GetTopSaledProducts(startReportDateTime, page, countAtPage);
            
            return report;
        }
    }
}