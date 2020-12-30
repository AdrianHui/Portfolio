using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
