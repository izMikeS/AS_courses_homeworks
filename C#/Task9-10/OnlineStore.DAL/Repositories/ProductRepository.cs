using OnlineStore.DBA.Contracts;
using System.Linq;

namespace OnlineStore.DBA.Repositories
{
    public class ProductRepository : BaseRepository, IRepository<Product, int>
    {
        public void Create(Product entity)
        {
            using (var context = CreateContext())
            {
                context.Products.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (var context = CreateContext())
            {
                context.Products.Remove(entity);
                context.SaveChanges();
            }
        }

        public Product GetById(int id)
        {
            using (var context = CreateContext())
            {
                return context.Products.Single(e => e.Id == id);
            }
        }

        public void Update(Product entity)
        {
            using (var context = CreateContext())
            {
                var product = context.Products.Single(c => c.Id == entity.Id);

                product.Name = entity.Name;
                product.Manufacturer = entity.Manufacturer;
                product.ManafacturerId = entity.ManafacturerId;
                product.Price = entity.Price;
                product.ProductAtOrders = entity.ProductAtOrders;
                product.Category = entity.Category;
                product.CategoryId = entity.CategoryId;
                product.Description = entity.Description;

                context.SaveChanges();
            }
        }
    }
}
