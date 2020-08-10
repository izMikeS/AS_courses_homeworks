using System;
using System.Linq;

namespace FirstSubtask
{

    public class DefaultUser : User
    {
        private FileManager<Product> productsFile;
        private Cart cart;
        public Cart Cart
        {
            get => cart;
            set => cart = value ??
            throw new ArgumentNullException(nameof(cart), "The value cannot be null");
        }

        public void AddToCart(Product product)
        {
            var products = productsFile.Load();

            if (products.FirstOrDefault(p => p.Name == product.Name) == null)
                throw new ArgumentNullException(nameof(product), "This product is not in the list of available products.");

            Cart.Add(product);
        }
        public void RemoveFromCart(Product product)
        {
            cart.Remove(product.Name);
        }

        public DefaultUser()
        {
            productsFile = new FileManager<Product>(FilePaths.PRODUCTS);
        }
        public DefaultUser(string userName, string hashedPass, Cart cart, string productsFilePath)
            : base(userName, hashedPass)
        {
            Cart = cart;
            productsFile = new FileManager<Product>(productsFilePath);
        }
    }
}
