using OnlineStore.DAL.Contracts;
using OnlineStore.DAL.Dtos.Models;
using OnlineStore.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.DAL.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(StoreDbContext s) : base(s)
        {
        }

        public void Create(CustomerDto entity)
        {
                Context.Customers.Add(entity.ToEntityModel());
                Context.SaveChanges();
        }

        public void Delete(int id)
        {
                Context.Customers.Remove(Context.Customers.Single(e => e.Id == id));
                Context.SaveChanges();
        }

        public List<CustomerDto> GetAll(int skip, int take)
        {
                return Context.Customers
                    .OrderBy(p => p.Username)
                    .Skip(skip).Take(take)
                    .ToList().Select(c => c.ToDataDto())
                    .ToList();
        }

        public CustomerDto GetById(int id)
        {
                return Context.Customers.Single(e => e.Id == id).ToDataDto();
        }

        public void Update(CustomerDto entity)
        {
                var customer = Context.Customers.Single(c => c.Id == entity.Id);

                customer.Username = entity.Username;
                customer.Email = entity.Email;

                Context.SaveChanges();
        }

        public CustomerDto GetByAuthId(string authId)
        {
            return Context.Customers.Single(c => c.AuthId == authId).ToDataDto();
        }
    }
}
