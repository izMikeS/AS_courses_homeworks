using OnlineStore.DBA.Contracts;
using System.Linq;

namespace OnlineStore.DBA.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer, int>
    {
        public void Create(Customer entity)
        {
            using (var context = CreateContext())
            {
                context.Customers.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Customer entity)
        {
            using (var context = CreateContext())
            {
                context.Customers.Remove(entity);
                context.SaveChanges();
            }
        }

        public Customer GetById(int id)
        {
            using (var context = CreateContext())
            {
                return context.Customers.Single(e => e.Id == id);
            }
        }

        public void Update(Customer entity)
        {
            using (var context = CreateContext())
            {
                var customer = context.Customers.Single(c => c.Id == entity.Id);

                customer.Username = entity.Username;
                customer.Email = entity.Email;
                customer.Orders = entity.Orders;

                context.SaveChanges();
            }
        }
    }
}
