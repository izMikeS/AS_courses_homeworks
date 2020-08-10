namespace OnlineStore.BLL.Mappers
{
    public static class OrderMapper
    {
        public static DAL.Dtos.Models.OrderDto ToDataDto(this Dtos.Models.OrderDto model)
        {
            return new DAL.Dtos.Models.OrderDto
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Date = model.Date,
                Status = model.Status
            };
        }
        public static BLL.Dtos.Models.OrderDto ToDto(this DAL.Dtos.Models.OrderDto model)
        {
            return new BLL.Dtos.Models.OrderDto
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Status = model.Status,
                Date = model.Date
            };
        }
    }
}
