using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stock
{
    internal class Stock<T> : IEnumerable<T>
        where T : IProduct
    {
        private readonly List<T> products;
        private readonly Action<T> act;

        public Stock(Action<T> act = null)
        {
            products = new List<T>();
            this.act = act;
        }

        public void AddProduct(T product)
        {
            if (products.Any(prod => prod.Name == product.Name))
            {
                T current = products.First(prod => prod.Name == product.Name);
                current.Quantity = products.Aggregate(
                    current.Quantity, (seed, num) => seed + product.Quantity);
                return;
            }

            products.Add(product);
        }

        public void SellProduct(T product)
        {
            T current = products.First(prod => prod.Name == product.Name);
            if (current.Quantity < product.Quantity)
            {
                throw new InvalidOperationException(
                    "There is not enough quantity on stock.");
            }
            else if (current.Quantity > product.Quantity)
            {
                current.Quantity = products.Aggregate(
                    current.Quantity, (seed, num) => seed - product.Quantity);
                act?.Invoke(current);
                return;
            }

            products.RemoveAt(products.IndexOf(current));
        }

        public int CheckQuantity(T product)
        {
            return products.Single(prod => prod.Name == product.Name).Quantity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var prod in products)
            {
                yield return prod;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
