using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Mappers
{
    public static class ProductAtOrderMapper
    {
        public static ProductAtOrderDto ToDataDto(this ProductAtOrder model)
        {
            return new ProductAtOrderDto
            {
                Id = model.Id,
               Count = model.Count,
               OrderId = model.OrderId,
               ProductId = model.ProductId
            };
        }
        public static ProductAtOrder ToEntityModel(this ProductAtOrderDto model)
        {
            return new ProductAtOrder
            {
                Id = model.Id,
                Count = model.Count,
                OrderId = model.OrderId,
                ProductId = model.ProductId
            };
        }
    }
}
