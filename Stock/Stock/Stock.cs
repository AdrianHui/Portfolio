using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stock
{
    internal class Stock<T> : IEnumerable<T>
        where T : IProduct
    {
        private readonly int[] limits = { 2, 5, 10 };
        private readonly List<T> products;

        public Stock()
        {
            products = new List<T>();
        }

        public event Action<T> Notify;

        public void AddProduct(T product)
        {
            T current = products.FirstOrDefault(prod => prod.Name == product.Name);
            if (current != null)
            {
                current.Quantity += product.Quantity;
                return;
            }

            products.Add(product);
        }

        public void SellProduct(T product)
        {
            T current = products.FirstOrDefault(prod => prod.Name == product.Name);
            if (current == null || current.Quantity < product.Quantity)
            {
                throw new InvalidOperationException(
                    "The product is not on stock or there is not enough quantity.");
            }
            else if (current.Quantity > product.Quantity)
            {
                int limit = GetCrossedLimit(current.Quantity, product.Quantity);
                current.Quantity -= product.Quantity;
                if (limit != -1)
                {
                    Notify?.Invoke(current);
                }

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

        private int GetCrossedLimit(int currentQty, int qtyToSell)
        {
            foreach (var limit in limits)
            {
                if (currentQty > limit && currentQty - qtyToSell < limit)
                {
                    return limit;
                }
            }

            return -1;
        }
    }
}
