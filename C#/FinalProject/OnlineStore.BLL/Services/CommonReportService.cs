using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;
using OnlineStore.DAL.Contracts;
using System.Linq;

namespace OnlineStore.BLL.Services
{
    public class CommonReportService : ICommonReportService
    {
        ICategoryRepository _categoryRepository;
        IProductAtOrderService _productAtOrderService;

        public CommonReportService(ICategoryRepository c, IProductAtOrderService po)
        {
            _categoryRepository = c;
            _productAtOrderService = po;
        }

        public CommonReportDto GetReport(ReportTimeType timeSpan, int categoryId,
            int productsPage = 1, int countAtPage = 10)
        {
            var startReportDateTime = ProjectUtils.GetStartReportDateTime(timeSpan);

            var category = _categoryRepository.GetById(categoryId);

            var commonReport = new CommonReportDto
            {
                ReportTime = timeSpan,
                CategoryName = category.Name
            };

            commonReport.Products = _productAtOrderService.GetReportProductsAtCategoryOrderBySum(startReportDateTime,
                categoryId, productsPage, countAtPage);

            commonReport.TotalSalesSum = _productAtOrderService.GetTotalSalesSum(startReportDateTime);
            commonReport.TotalSalesSumAtCategory = commonReport.Products.Sum(p => p.SalesSum);
            commonReport.SalesCountAtCategory = (uint)commonReport.Products.Sum(p => p.SalesCount);


            return commonReport;
        }
    }
}