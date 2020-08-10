using OnlineStore.BLL.Dtos.Models;
using OnlineStore.Common;
using System.Collections.Generic;

namespace OnlineStore.BLL.Contracts
{
    public interface IOrderService : IService<OrderDto, int>
    {
        OrderDto GetCustomerCart(int customerId);

        List<OrderDto> GetAllByStatus(OrderStatus status, int page = 1, int countAtPage = 10);
        List<OrderDto> GetAllByStatusAndCustomer(OrderStatus? status, int? customerId, int page = 1, int countAtPage = 10);
    }
}
