using OnlineStore.BLL.Dtos.Models;

namespace OnlineStore.BLL.Contracts
{
    public interface ICustomerService : IService<CustomerDto, int>
    {
        CustomerDto GetByAuthId(string authId);
    }
}
