namespace OnlineStore.BLL.Mappers
{
    public static class CustomerMapper
    {
        public static DAL.Dtos.Models.CustomerDto ToDataDto(this Dtos.Models.CustomerDto model)
        {
            return new DAL.Dtos.Models.CustomerDto
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                AuthId = model.AuthId
            };
        }
        public static Dtos.Models.CustomerDto ToDto(this DAL.Dtos.Models.CustomerDto model)
        {
            return new BLL.Dtos.Models.CustomerDto
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                AuthId = model.AuthId
            };
        }
    }
}
