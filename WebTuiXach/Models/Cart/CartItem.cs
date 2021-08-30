using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTuiXach.Models.Cart
{
    public class CartItem
    {
        public Product product { set; get; }
        public int Quantity { set; get; }
    }
}