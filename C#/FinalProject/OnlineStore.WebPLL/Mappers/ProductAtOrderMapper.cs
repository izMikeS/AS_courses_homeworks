using OnlineStore.BLL.Dtos.Models;
using OnlineStore.WebPLL.Models.FullModels;
using OnlineStore.WebPLL.Models.ShortModels;

namespace OnlineStore.WebPLL.Mappers
{
    public static class ProductAtOrderMapper
    {
        public static ProductAtOrderShortViewModel ToViewModel(this ProductAtOrderDto model)
        {
            return new ProductAtOrderShortViewModel
            {
                Id = model.Id,
                Count = model.Count,
                OrderId = model.OrderId,
                ProductId = model.ProductId
            };
        }
        public static ProductAtOrderDto ToDto(this ProductAtOrderShortViewModel model)
        {
            return new ProductAtOrderDto
            {
                Id = model.Id,
                Count = model.Count,
                OrderId = model.OrderId,
                ProductId = model.ProductId 
            };
        } 
        public static ProductAtOrderFullViewModel ToViewModel(this FullProductAtOrderDto model)
        {
            return new ProductAtOrderFullViewModel
            {
                Product = model.Product.ToViewModel(),
                Count = model.Count,
                OrderId = model.OrderId
            };
        }
    }
}
