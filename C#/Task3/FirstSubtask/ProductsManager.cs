using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSubtask
{
    public class ProductsManager
    {
        private FileManager<Product> productsFile;

        public ProductsManager(string productsFilePath)
        {
            productsFile = new FileManager<Product>(productsFilePath);
        }

        public Product[] Search(string searchRequest)
        {
            var products = productsFile.Load();

            return products.Where(p => p.Name.Contains(searchRequest)
            || p.Description.Contains(searchRequest)).ToArray();
        }
        public void Remove(Product product)
        {
            var products = productsFile.Load();
            productsFile.SaveFromArray(products.Where(p => p.Name != product.Name).ToArray());
        }
    }
}
