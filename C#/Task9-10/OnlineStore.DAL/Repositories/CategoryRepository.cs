using OnlineStore.DBA.Contracts;
using System.Linq;

namespace OnlineStore.DBA.Repositories
{
    public class CategoryRepository : BaseRepository, IRepository<Category, int>
    {
        public void Create(Category entity)
        {
            using (var context = CreateContext())
            {
                context.Categories.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (var context = CreateContext())
            {
                context.Categories.Remove(entity);
                context.SaveChanges();
            }
        }

        public Category GetById(int id)
        {
            using (var context = CreateContext())
            {
                return context.Categories.Single(e => e.Id == id);
            }
        }

        public void Update(Category entity)
        {
            using (var context = CreateContext())
            {
                var category = context.Categories.Single(c=> c.Id == entity.Id);
                category.Name = entity.Name;
                category.Products = entity.Products;
                context.SaveChanges();
            }
        }
    }
}
