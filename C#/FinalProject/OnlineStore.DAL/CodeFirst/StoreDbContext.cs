using System.Data.Entity;

namespace OnlineStore.DAL
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base("StoreDatabaseCF") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAtOrder> ProductAtOrders { get; set; }
    }
}
