using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;

namespace OnlineStore.BLL.Services
{
    public class HalfOrderService : IHalfOrderService
    {
        ICustomerService _customerService;

        public HalfOrderService(ICustomerService c)
        {
            _customerService = c;
        }

        public HalfOrderDto GetByShortModel(OrderDto model)
        {
            var customer = _customerService.GetById(model.CustomerId);
            return new HalfOrderDto
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                CustomerName = customer.Username,
                Date = model.Date,
                Status = model.Status
            };
        }
    }
}
