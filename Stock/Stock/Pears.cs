using System;

namespace Stock
{
    class Pears : IProduct
    {
        public Pears(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
