using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;
using System.Linq;

namespace OnlineStore.BLL.Services
{
    public class FullOrderService : IFullOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductAtOrderRepository _productAtOrderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFullProductAtOrderService _fullProductAtOrderService;
        private readonly IHalfOrderService _orderFullShortService;

        public FullOrderService(IOrderRepository o, IProductAtOrderRepository po,
            IProductRepository p, IFullProductAtOrderService fpo,
            IHalfOrderService ofp)
        {
            _orderRepository = o;
            _productAtOrderRepository = po;
            _productRepository = p;
            _fullProductAtOrderService = fpo;
            _orderFullShortService = ofp;
        }

        public FullOrderDto GetById(int id)
        {
            var order = _orderRepository.GetById(id).ToDto();

            var fullProductsAtOrder = _productAtOrderRepository.GetProductsAtOrder(order.Id)
                .Select(p => _fullProductAtOrderService.GetByShortModel(p.ToDto())).ToList();

            var totalSum = fullProductsAtOrder.Sum(p =>
            _productRepository.GetById(p.ProductId).Price * p.Count);

            return new FullOrderDto
            {
                Order = _orderFullShortService.GetByShortModel(order),
                Products = fullProductsAtOrder,
                TotalPrice = totalSum

            };
        }
    }
}