using OnlineStore.DBA.Contracts;
using System.Linq;

namespace OnlineStore.DBA.Repositories
{
    public class ManufacturerRepository : BaseRepository, IRepository<Manufacturer, int>
    {
        public void Create(Manufacturer entity)
        {
            using (var context = CreateContext())
            {
                context.Manufacturers.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Manufacturer entity)
        {
            using (var context = CreateContext())
            {
                context.Manufacturers.Remove(entity);
                context.SaveChanges();
            }
        }

        public Manufacturer GetById(int id)
        {
            using (var context = CreateContext())
            {
                return context.Manufacturers.Single(e => e.Id == id);
            }
        }

        public void Update(Manufacturer entity)
        {
            using (var context = CreateContext())
            {
                var manufacturer = context.Manufacturers.Single(c => c.Id == entity.Id);

                manufacturer.Name = entity.Name;
                manufacturer.Products = entity.Products;

                context.SaveChanges();
            }
        }
    }
}
