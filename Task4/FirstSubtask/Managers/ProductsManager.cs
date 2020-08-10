using FirstSubtask.Models;
using System.Linq;

namespace FirstSubtask.Managers
{
    public class ProductsManager : FileManager<Product>
    {
        public ProductsManager(string productsFilePath)
            : base(productsFilePath) { }

        public string GetProductInfoByName(string productName)
        {
            var products = Load();
            return products.FirstOrDefault(p => p.Name == productName)?.ToString();
        }


    }
}
