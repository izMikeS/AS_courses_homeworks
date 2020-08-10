using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FirstSubtask.Models
{
    public class Cart : IEnumerable<Product>, IEnumerator<Product>
    {
        private Product[] _products;
        private int _currentIndex;
        private SortType _sortBy;

        public Cart(SortType sortBy)
            : this()
        {
            _sortBy = sortBy;
        }

        public Cart()
        {
            _products = new Product[0];
            _currentIndex = -1;
        }

        public enum SortType
        {
            Name,
            Description,
            Type,
            Price
        }

        public int Length => _products.Length;

        public Product Current => _products[_currentIndex];
    
        object IEnumerator.Current => _products[_currentIndex];
       
        public decimal TotalPrice { get; private set; }
    
        public SortType SortBy
        {
            get => _sortBy;
            set
            {
                _sortBy = value;
                Sort();
            }
        }

        public Product this[int index] => _products[index];

        public void Add(Product product)
        {
            if (Contains(product.Name))
            {
                throw new ArgumentException("The name must be unique.", nameof(product.Name));
            }

            _products = _products.Append(product).ToArray();
            RecountCollection();
        }

        public void Remove(string productName)
        {
            if (!Contains(productName))
            {
                throw new ArgumentException("The cart does not contain a product with the given name.", nameof(productName));
            }

            _products = _products.Where(p => p.Name != productName).ToArray();
            RecountCollection();
        }

        public void Update(string productName, Product updatedProduct)
        {
            Remove(productName);
            Add(updatedProduct);
        }
        public Product[] Search(string searchRequest)
        {
            return _products.Where(p => p.Name.Contains(searchRequest)
            || p.Description.Contains(searchRequest)).ToArray();
        }

        public bool Contains(string productName)
        {
            return _products.Count(p => p.Name == productName) == 1;
        }

        public bool MoveNext()
        {
            if (_currentIndex < _products.Length - 1)
            {
                ++_currentIndex;
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
            _currentIndex = -1;
        }

        private void RecountCollection()
        {
            Sort();
            CountTotalPrice();
        }

        private void Sort()
        {
            IOrderedEnumerable<Product> orderedEnumerableProducts;
            switch (_sortBy)
            {
                case SortType.Name:
                default:
                    orderedEnumerableProducts = _products.OrderBy(p => p.Name);
                    break;
                case SortType.Description:
                    orderedEnumerableProducts = _products.OrderBy(p => p.Description);
                    break;
                case SortType.Type:
                    orderedEnumerableProducts = _products.OrderBy(p => p.Type);
                    break;
                case SortType.Price:
                    orderedEnumerableProducts = _products.OrderBy(p => p.Price);
                    break;

            }
            _products = orderedEnumerableProducts.ToArray();

        }

        private void CountTotalPrice()
        {
            TotalPrice = _products.Sum(p => p.Price);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        public void Dispose() { }

        IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
        {
            return this as IEnumerator<Product>;
        }
    }
}
