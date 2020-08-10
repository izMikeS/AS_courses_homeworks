using System.Collections.Generic;
using System.Linq;
using OnlineStore.BLL.Contracts;
using OnlineStore.BLL.Dtos.Models;
using OnlineStore.BLL.Mappers;
using OnlineStore.DAL.Contracts;

namespace OnlineStore.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRep;

        public CustomerService(ICustomerRepository c)
        {
            _customerRep = c;
        }

        public void Create(CustomerDto entity)
        {
            _customerRep.Create(entity.ToDataDto());
        }

        public void Delete(int id)
        {
            _customerRep.Delete(id);
        }

        public CustomerDto GetById(int id)
        {
            return _customerRep.GetById(id).ToDto();
        }

        public void Update(CustomerDto entity)
        {
            _customerRep.Update(entity.ToDataDto());
        }

        public List<CustomerDto> GetAllAtPage(int page = 1, int countAtPage = 10)
        {
            var skipTake = ProjectUtils.GetSkipAndTakeCounts(page, countAtPage);

            return _customerRep.GetAll(skipTake.skip, skipTake.take).Select(p => p.ToDto()).ToList();
        }

        public CustomerDto GetByAuthId(string authId)
        {
            return _customerRep.GetByAuthId(authId).ToDto();
        }
    }
}
