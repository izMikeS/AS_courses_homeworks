using OnlineStore.DAL.Dtos.Models;

namespace OnlineStore.DAL.Contracts
{
    public interface ICustomerRepository : IRepository<CustomerDto, int>
    {
        CustomerDto GetByAuthId(string authId);
    }
}
