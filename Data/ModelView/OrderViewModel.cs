using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelView
{
    public class OrderViewModel
    {
        public long OrderID { set; get; }
        public long ProductID { set; get; }
        public string ProductName { set; get; }
        public int? Quantity { set; get; }
        public decimal? Price { set; get; }
        public DateTime? CreatedDate { get; set; }
        public bool nhanhang { set; get; }
    }
}
