using OnlineStore.DBA.Contracts;
using System.Linq;

namespace OnlineStore.DBA.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order, int>
    {
        public void Create(Order entity)
        {
            using (var context = CreateContext())
            {
                context.Orders.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Order entity)
        {
            using (var context = CreateContext())
            {
                context.Orders.Remove(entity);
                context.SaveChanges();
            }
        }

        public Order GetById(int id)
        {
            using (var context = CreateContext())
            {
                return context.Orders.Single(e => e.Id == id);
            }
        }

        public void Update(Order entity)
        {
            using (var context = CreateContext())
            {
                var order = context.Orders.Single(c => c.Id == entity.Id);

                order.Customer = entity.Customer;
                order.CustomerId = entity.CustomerId;
                order.ProductAtOrders = entity.ProductAtOrders;
                order.Date = entity.Date;
                order.Status = entity.Status;

                context.SaveChanges();
            }
        }
    }
}
