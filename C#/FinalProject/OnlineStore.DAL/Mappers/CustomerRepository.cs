using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToDataDto(this Customer model)
        {
            return new CustomerDto
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                AuthId = model.AuthId
            };
        }
        public static Customer ToEntityModel(this CustomerDto model)
        {
            return new Customer
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                AuthId = model.AuthId
            };
        }
    }
}
