using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDataDto(this Order model)
        {
            return new OrderDto
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Date = model.Date,
                Status = model.Status
            };
        }
        public static Order ToEntityModel(this OrderDto model)
        {
            return new Order
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Date = model.Date,
                Status = model.Status
            };
        }
    }
}
