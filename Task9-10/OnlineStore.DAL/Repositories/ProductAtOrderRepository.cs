using OnlineStore.DBA.Contracts;
using System.Linq;

namespace OnlineStore.DBA.Repositories
{
    public class ProductAtOrderRepository : BaseRepository, IRepository<ProductAtOrder, int>
    {
        public void Create(ProductAtOrder entity)
        {
            using (var context = CreateContext())
            {
                context.ProductAtOrders.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(ProductAtOrder entity)
        {
            using (var context = CreateContext())
            {
                context.ProductAtOrders.Remove(entity);
                context.SaveChanges();
            }
        }

        public ProductAtOrder GetById(int id)
        {
            using (var context = CreateContext())
            {
                return context.ProductAtOrders.Single(e => e.Id == id);
            }
        }

        public void Update(ProductAtOrder entity)
        {
            using (var context = CreateContext())
            {
                var productAtOrder = context.ProductAtOrders.Single(c => c.Id == entity.Id);

                productAtOrder.Order = entity.Order;
                productAtOrder.OrderId = entity.OrderId;
                productAtOrder.Product = entity.Product;
                productAtOrder.ProductId = entity.ProductId;
                productAtOrder.Count = entity.Count;
                
                context.SaveChanges();
            }
        }
    }
}
