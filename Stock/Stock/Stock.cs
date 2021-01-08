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
                bool hasCrossedALimit = HasCrossedALimit(current.Quantity, product.Quantity);
                current.Quantity -= product.Quantity;
                if (hasCrossedALimit)
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

        private bool HasCrossedALimit(int currentQty, int qtyToSell)
        {
            return limits.Any(x => currentQty > x && currentQty - qtyToSell < x);
        }
    }
}
