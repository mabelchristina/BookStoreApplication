using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CartResponse
    {
        public int UserId { get; set; }

        public string BookTitle { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
