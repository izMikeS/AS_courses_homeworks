using OnlineStore.BLL.Dtos.Models;

namespace OnlineStore.BLL.Contracts
{
    public interface IFullProductAtOrderService
    {
        FullProductAtOrderDto GetByShortModel(ProductAtOrderDto model);
    }
}