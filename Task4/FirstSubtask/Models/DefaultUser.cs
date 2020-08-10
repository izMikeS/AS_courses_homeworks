using FirstSubtask.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSubtask.Models
{

    public class DefaultUser : User
    {
        private readonly ProductsManager _productsManager;
        private Cart _cart;

        public DefaultUser()
        {
            _productsManager = new ProductsManager(FilePaths.PRODUCTS);
        }

        public DefaultUser(string userName, string hashedPass, Cart cart, string productsFilePath)
            : base(userName, hashedPass)
        {
            Cart = cart;
            _productsManager = new ProductsManager(productsFilePath);
        }

        public Cart Cart
        {
            get => _cart;
            set => _cart = value ??
            throw new ArgumentNullException(nameof(_cart), "The value cannot be null");
        }

        public void AddToCart(Product product)
        {
            List<Product> products = _productsManager.Load();

            if (!products.Any(p => p.Name == product.Name))
            {
                throw new ArgumentNullException(nameof(product), "This product is not in the list of available products.");
            }

            Cart.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            _cart.Remove(product.Name);
        }
    }
}
