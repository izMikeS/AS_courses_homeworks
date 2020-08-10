using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;

namespace OnlineStore.BLL.Services
{
    public class FullProductAtOrderService : IFullProductAtOrderService
    {
        IProductRepository _productRepository;
        public FullProductAtOrderService(IProductRepository p)
        {
            _productRepository = p;
        }

        public FullProductAtOrderDto GetByShortModel(ProductAtOrderDto model)
        {
            var product = _productRepository.GetById(model.ProductId);
            return new FullProductAtOrderDto
            {
                Id = model.Id,
                Count = model.Count,
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Product = product.ToDto()
            };
        }
    }
}
