using OnlineStore.Common;
using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Dtos.Models;
using OnlineStore.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.DAL.Repositories
{
    public class ProductAtOrderRepository : BaseRepository, IProductAtOrderRepository
    {
        public ProductAtOrderRepository(StoreDbContext s) : base(s)
        {
        }

        public void Create(ProductAtOrderDto entity)
        {
            Context.ProductAtOrders.Add(entity.ToEntityModel());
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.ProductAtOrders.Remove(Context.ProductAtOrders.Single(e => e.Id == id));
            Context.SaveChanges();
        }

        public List<ProductAtOrderDto> GetAll(int skip, int take)
        {
            return Context.ProductAtOrders
                .OrderBy(p => p.Id)
                .Skip(skip).Take(take)
                .ToList().Select(c => c.ToDataDto())
                .ToList();
        }

        public ProductAtOrderDto GetById(int id)
        {
            return Context.ProductAtOrders.Single(e => e.Id == id).ToDataDto();
        }

        public void Update(ProductAtOrderDto entity)
        {
            var productAtOrder = Context.ProductAtOrders.Single(c => c.Id == entity.Id);

            productAtOrder.OrderId = entity.OrderId;
            productAtOrder.ProductId = entity.ProductId;
            productAtOrder.Count = entity.Count;

            Context.SaveChanges();
        }

        public List<ProductAtOrderDto> GetProductsAtOrder(int orderId)
        {
            return Context.ProductAtOrders.Where(p => p.OrderId == orderId)
                .ToList().Select(p => p.ToDataDto())
                .ToList();
        }

        public List<ReportProductDto> GetReportProductsAtCategoryOrderBySum(DateTime startDateTime, int categoryId,
            int skip, int take)
        {
            return Context.ProductAtOrders.Where(p => p.Order.Date > startDateTime
            && p.Order.Status == OrderStatus.Finished.ToString()
            && p.Product.Category.Id == categoryId)
                .GroupBy(p => p.Product.Name)
                .Select(p =>
                    new ReportProductDto
                    {
                        Name = p.Key,
                        ManafacturerName = p.FirstOrDefault().Product.Manufacturer.Name,
                        SalesCount = p.Sum(pr => pr.Product.ProductAtOrders.Count),
                        SalesSum = p.Sum(pr => pr.Product.Price * pr.Count)
                    })
                .OrderByDescending(p => p.SalesSum)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
        public decimal GetTotalSalesSum(DateTime startDateTime)
        {
            return Context.ProductAtOrders.Where(p => p.Order.Date > startDateTime
            && p.Order.Status == OrderStatus.Finished.ToString())
                .Select(p => p.Product.Price * p.Count).DefaultIfEmpty()
                .Sum(p => p);
        }

        public List<ReportProductForTopDto> GetTopSaledProducts(DateTime startDateTime, int skip, int take)
        {
            return Context.ProductAtOrders
                .Where(p => p.Order.Date > startDateTime
                         && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .OrderByDescending(p => p.Sum(pr => pr.Count))
                .Skip(skip)
                .Take(take)
                .Select(p => new ReportProductForTopDto
                {
                    ProductName = p.Key,
                    CategoryName = p.FirstOrDefault().Product.Category.Name,
                    SalesCount = p.Sum(pr => pr.Count),
                    SalesSum = p.Sum(pr => pr.Count * pr.Product.Price)
                }).ToList();
        }

        public decimal GetSalesSum(int productId, DateTime startDateTime)
        {
            return Context.ProductAtOrders.Where(p => p.Product.Id == productId
                                                        && p.Order.Date > startDateTime
                                                        && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count * pr.Product.Price)).DefaultIfEmpty()
                .Sum(p => p);
        }

        public uint GetSalesCount(int productId, DateTime startDateTime)
        {
            return (uint)Context.ProductAtOrders.Where(p => p.Product.Id == productId
                                                                    && p.Order.Date > startDateTime
                                                                    && p.Order.Status == OrderStatus.Finished.ToString())
                .GroupBy(p => p.Product.Name)
                .Select(p => p.Sum(pr => pr.Count)).DefaultIfEmpty()
                .Sum(p => p);
        }

        public ProductAtOrderDto GetByProductAndOrder(int productId, int orderId)
        {
            return Context.ProductAtOrders.FirstOrDefault(p => p.ProductId == productId
            && p.OrderId == orderId)?.ToDataDto();
        }
    }
}
