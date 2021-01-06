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
            if (products.Any(prod => prod.GetType().Equals(product.GetType())))
            {
                products[products.FindIndex(prod => prod.GetType().Equals(product.GetType()))]
                    .Quantity += product.Quantity;
                return;
            }

            products.Add(product);
        }

        public void SellProduct(T product)
        {
            int prodIndex =
                products.FindIndex(prod => prod.GetType().Equals(product.GetType()));
            if (prodIndex == -1 || products[prodIndex].Quantity < product.Quantity)
            {
                throw new InvalidOperationException(
                    "The product is not on stock or there is not enough quantity.");
            }
            else if (products[prodIndex].Quantity > product.Quantity)
            {
                products[prodIndex].Quantity -= product.Quantity;
                act?.Invoke(products[prodIndex]);
                return;
            }

            products.RemoveAt(prodIndex);
        }

        public int CheckQuantity(T product)
        {
            return products.Single(prod => prod.GetType().Equals(product.GetType())).Quantity;
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
