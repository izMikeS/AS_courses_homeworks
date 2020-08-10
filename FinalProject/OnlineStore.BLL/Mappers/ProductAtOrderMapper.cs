using OnlineStore.BLL.Services;

namespace OnlineStore.BLL.Mappers
{
    public static class ProductAtOrderMapper
    {
        public static DAL.Dtos.Models.ProductAtOrderDto ToDataDto(this Dtos.Models.ProductAtOrderDto model)
        {
            return new DAL.Dtos.Models.ProductAtOrderDto
            {
                Id = model.Id,
                Count = model.Count,
                OrderId = model.OrderId,
                ProductId = model.ProductId
            };
        }
        public static Dtos.Models.ProductAtOrderDto ToDto(this DAL.Dtos.Models.ProductAtOrderDto model)
        {
            return new BLL.Dtos.Models.ProductAtOrderDto
            {
                Id = model.Id,
                Count = model.Count,
                OrderId = model.OrderId,
                ProductId = model.ProductId 
            };
        }
    }
}
