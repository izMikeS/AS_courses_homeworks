using OnlineStore.BLL.Dtos.Models;
using System;
using System.Collections.Generic;

namespace OnlineStore.BLL.Contracts
{
    public interface IProductAtOrderService : IService<ProductAtOrderDto, int>
    {
        decimal GetTotalSalesSum(DateTime startDateTime);
        List<ReportProductDto> GetReportProductsAtCategoryOrderBySum(DateTime startDateTime, int categoryId,
            int page = 1, int countAtPage = 10);
        List<ReportProductForTopDto> GetTopSaledProducts(DateTime startDateTime, int page = 1, int countAtPage = 10);
        decimal GetSalesSum(int productId, DateTime startDateTime);
        uint GetSalesCount(int productId, DateTime startDateTime);
        ProductAtOrderDto GetByProductAndOrder(int productId, int orderId);
    }
}
