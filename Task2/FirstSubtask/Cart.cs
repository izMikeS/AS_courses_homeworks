using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FirstSubtask
{
    public class Cart : IEnumerable<Product>, IEnumerator<Product>
    {
        private Product[] products;
        private int currentIndex;
        private SortType sortBy;

        public Cart(SortType sortBy = default)
        {
            this.products = new Product[0];
            this.sortBy = sortBy;
            this.currentIndex = -1;
        }
        public enum SortType
        {
            Name,
            Description,
            Type,
            Price
        }
        public int Length => products.Length;
        public object Current => products[currentIndex];
        Product IEnumerator<Product>.Current => products[currentIndex];
        public decimal TotalPrice { get; private set; }
        public SortType SortBy
        {
            get => sortBy;
            set
            {
                sortBy = value;
                Sort();
            }
        }


        public Product this[int index]
        {
            get => products[index];
        }
        public void Add(Product product)
        {
            if (this.Contains(product.Name))
            {
                throw new ArgumentException("The name must be unique.", nameof(product.Name));
            }

            products = products.Append(product).ToArray();
            RecountCollection();
        }
        public void Remove(string productName)
        {
            if (!this.Contains(productName))
            {
                throw new ArgumentException("The cart does not contain a product with the given name.", nameof(productName));
            }

            products = products.Where(p => p.Name != productName).ToArray();
            RecountCollection();
        }
        public void Update(string productName, Product updatedProduct)
        {
            Remove(productName);
            Add(updatedProduct);
        }
        public Product[] Search(string searchRequest)
        {
            return products.Where(p => p.Name.Contains(searchRequest) 
            || p.Description.Contains(searchRequest)).ToArray();
        }
        public bool Contains(string productName)
        {
            return products.Count(p => p.Name == productName) == 1;
        }
        public bool MoveNext()
        {
            if (currentIndex < products.Length - 1)
            {
                ++currentIndex;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }
        public void Reset()
        {
            currentIndex = -1;
        }
        private void RecountCollection()
        {
            Sort();
            CountTotalPrice();
        }
        private void Sort()
        {
            IOrderedEnumerable<Product> orderedEnumerableProducts;
            switch (sortBy)
            {
                case SortType.Name:
                default:
                    orderedEnumerableProducts = products.OrderBy(p => p.Name);
                    break;
                case SortType.Description:
                    orderedEnumerableProducts = products.OrderBy(p => p.Description);
                    break;
                case SortType.Type:
                    orderedEnumerableProducts = products.OrderBy(p => p.Type);
                    break;
                case SortType.Price:
                    orderedEnumerableProducts = products.OrderBy(p => p.Price);
                    break;

            }
            products = orderedEnumerableProducts.ToArray();

        }
        private void CountTotalPrice()
        {
            TotalPrice = products.Sum(p => p.Price);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return this as IEnumerator<Product>;
        }

        public void Dispose() { }
    }
}
