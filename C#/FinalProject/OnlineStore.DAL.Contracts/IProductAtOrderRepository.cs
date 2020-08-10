using OnlineStore.DAL.Dtos.Models;
using System;
using System.Collections.Generic;

namespace OnlineStore.DAL.Contracts
{
    public interface IProductAtOrderRepository : IRepository<ProductAtOrderDto, int>
    {
        List<ProductAtOrderDto> GetProductsAtOrder(int orderId);
        decimal GetTotalSalesSum(DateTime startDateTime);
        List<ReportProductDto> GetReportProductsAtCategoryOrderBySum(DateTime startDateTime, int categoryId,
            int skip, int take);
        List<ReportProductForTopDto> GetTopSaledProducts(DateTime startDateTime, int skip, int take);
        decimal GetSalesSum(int productId, DateTime startDateTime);
        uint GetSalesCount(int productId, DateTime startDateTime);
        ProductAtOrderDto GetByProductAndOrder(int productId, int orderId);
    }
}
