using System;

namespace Stock
{
    interface IProduct
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
