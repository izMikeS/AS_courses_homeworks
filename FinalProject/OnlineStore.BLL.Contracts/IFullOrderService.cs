using OnlineStore.BLL.Dtos.Models;

namespace OnlineStore.BLL.Contracts
{
    public interface IFullOrderService
    {
        FullOrderDto GetById(int id);
    }
}
