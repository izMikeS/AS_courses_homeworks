using OnlineStore.Common;
using OnlineStore.DAL.Dtos.Models;
using System.Collections.Generic;

namespace OnlineStore.DAL.Contracts
{
    public interface IOrderRepository : IRepository<OrderDto, int>
    {
        OrderDto GetCustomerCart(int customerId);
        List<OrderDto> GetAllByStatus(OrderStatus status, int skip, int take);
        List<OrderDto> GetByCustomer(int customerId, int skip, int take);
        List<OrderDto> GetByCustomerAndStatus(OrderStatus status, int customerId, int skip, int take);
    }
}
