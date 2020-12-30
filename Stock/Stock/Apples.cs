using System;

namespace Stock
{
    class Apples : IProduct
    {
        public Apples(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
