using OnlineStore.BLL.Dtos.Models;
using OnlineStore.WebPLL.Models.FullModels;
using OnlineStore.WebPLL.Models.ShortModels;
using System.Linq;

namespace OnlineStore.WebPLL.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(this OrderShortViewModel model)
        {
            return new OrderDto
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Status = model.Status,
                Date = model.Date
            };
        }
        public static OrderFullViewModel ToViewModel(this FullOrderDto model)
        {
            return new OrderFullViewModel
            {
                Order = model.Order.ToViewModel(),
                TotalPrice = model.TotalPrice,
                Products = model.Products.Select(p => p.ToViewModel()).ToList()
            };
        }

        public static OrderShortViewModel ToViewModel(this HalfOrderDto model)
        {
            return new OrderShortViewModel
            {
                CustomerId = model.CustomerId,
                CustomerName = model.CustomerName,
                Date = model.Date,
                Id = model.Id,
                Status = model.Status
            };
        }
    }
}
