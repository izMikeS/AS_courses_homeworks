using System;
using System.Linq;

namespace FirstSubtask
{
    public class Admin : User
    {
        public void AddProduct(Product product)
        {
            var productsFile = new FileManager<Product>(FilePaths.PRODUCTS);
            var products = productsFile.Load();

            if (products.FirstOrDefault(p => p.Name == product.Name) != null)
                throw new ArgumentException("A product with the same name already exists.", nameof(product));

            productsFile.AddOrUpdate(product);
        }
        public Admin() { }
        public Admin(string userName, string hashedPass)
            : base(userName, hashedPass) { }
    }
}
