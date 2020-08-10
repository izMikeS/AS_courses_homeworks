using OnlineStore.BLL.Dtos.Models;

namespace OnlineStore.BLL.Contracts
{
    public interface IHalfOrderService
    {
        HalfOrderDto GetByShortModel(OrderDto model);
    }
}