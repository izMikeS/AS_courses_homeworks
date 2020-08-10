using FirstSubtask.Managers;
using System;
using System.Linq;

namespace FirstSubtask.Models
{
    public class Admin : User
    {
        public Admin() { }

        public Admin(string userName, string hashedPass)
            : base(userName, hashedPass) { }

        public void AddProduct(Product product)
        {
            FileManager<Product> productsFile = new FileManager<Product>(FilePaths.PRODUCTS);
            var products = productsFile.Load();

            if (products.Any(p => p.Name == product.Name))
            {
                throw new ArgumentException("A product with the same name already exists.", nameof(product));
            }

            productsFile.AddOrUpdate(product);
        }
    }
}
