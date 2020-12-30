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

        public Stock()
        {
            products = new List<T>();
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
            if (products[prodIndex].Quantity < product.Quantity)
            {
                throw new InvalidOperationException("There is not enough quantity on stock.");
            }
            else if (products[prodIndex].Quantity > product.Quantity)
            {
                products[prodIndex].Quantity -= product.Quantity;
                LowQuantityCheck(products[prodIndex]);
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

        private void LowQuantityCheck(T product)
        {
            Action<T, int> lowStockWarning = (arg, min) =>
            {
                Console.WriteLine(
                    $"Remaining quantity for {arg} is less than {min}. " +
                    $"Current quantity: {arg.Quantity}.");
            };

            if (product.Quantity < 2)
            {
                lowStockWarning(product, 2);
            }
            else if (product.Quantity < 5)
            {
                lowStockWarning(product, 5);
            }
            else if (product.Quantity < 10)
            {
                lowStockWarning(product, 10);
            }
        }
    }
}
