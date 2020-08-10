using System;
using System.Collections.Generic;
using System.Linq;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;

namespace OnlineStore.BLL.Services
{
    public class ProductAtOrderService : IProductAtOrderService
    {
        private readonly IProductAtOrderRepository _productAtOrderRep;

        public ProductAtOrderService(IProductAtOrderRepository p)
        {
            _productAtOrderRep = p;
        }

        public void Create(ProductAtOrderDto entity)
        {
            _productAtOrderRep.Create(entity.ToDataDto());
        }

        public void Delete(int id)
        {
            _productAtOrderRep.Delete(id);
        }

        public ProductAtOrderDto GetById(int id)
        {
            return _productAtOrderRep.GetById(id).ToDto();
        }

        public void Update(ProductAtOrderDto entity)
        {
            _productAtOrderRep.Update(entity.ToDataDto());
        }

        public List<ProductAtOrderDto> GetAllAtPage(int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _productAtOrderRep.GetAll(skipTake.skip, skipTake.take).Select(p => p.ToDto()).ToList();
        }

        public decimal GetTotalSalesSum(DateTime startDateTime)
        {
            return _productAtOrderRep.GetTotalSalesSum(startDateTime);
        }

        public List<ReportProductDto> GetReportProductsAtCategoryOrderBySum(DateTime startDateTime,
            int categoryId, int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _productAtOrderRep.GetReportProductsAtCategoryOrderBySum(startDateTime,
                 categoryId, skipTake.skip, skipTake.take).Select(p => p.ToDto()).ToList();
        }

        public List<ReportProductForTopDto> GetTopSaledProducts(DateTime startDateTime,
            int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _productAtOrderRep.GetTopSaledProducts(startDateTime, skipTake.skip, skipTake.take)
                 .Select(p => p.ToDto()).ToList();
        }

        public decimal GetSalesSum(int productId, DateTime startDateTime)
        {
            return _productAtOrderRep.GetSalesSum(productId, startDateTime);
        }

        public uint GetSalesCount(int productId, DateTime startDateTime)
        {
            return _productAtOrderRep.GetSalesCount(productId, startDateTime);
        }

        public ProductAtOrderDto GetByProductAndOrder(int productId, int orderId)
        {
            return _productAtOrderRep.GetByProductAndOrder(productId, orderId)?.ToDto();
        }
    }
}
