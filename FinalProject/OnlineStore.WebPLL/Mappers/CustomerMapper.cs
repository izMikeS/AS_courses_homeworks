using OnlineStore.BLL.Dtos.Models;
using OnlineStore.WebPLL.Models;
using OnlineStore.WebPLL.Models.ShortModels;

namespace OnlineStore.WebPLL.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerShortViewModel ToViewModel(this CustomerDto model)
        {
            return new CustomerShortViewModel
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                AuthId  = model.AuthId
            };
        }
        public static CustomerDto ToDto(this CustomerShortViewModel model)
        {
            return new CustomerDto
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                AuthId = model.AuthId
            };
        }
    }
}
