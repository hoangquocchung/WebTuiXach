using Data.FE;
using Data.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class OrderDao
    {
        MyDB db = null;
        public OrderDao()
        {
            db = new MyDB();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            order.CreatedDate = DateTime.Now;
            db.SaveChanges();
            return order.ID;
        }

        public Order ViewDetail(long id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> ListAllOrder(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 5)
        {
            totalRecord = db.Orders.Count();
            IQueryable<Order> model = db.Orders;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipMobile.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public bool ChangeStatus(long id)
        {
            var order = db.Orders.Find(id);
            order.Status = !order.Status;

            db.SaveChanges();
            return order.Status;
        }
        public bool huy(long id)
        {
            var order = db.Orders.Find(id);
            order.trahang = !order.trahang;

            db.SaveChanges();
            return order.trahang;
        }
        public bool nhan(long id)
        {
            var order = db.Orders.Find(id);
            order.nhanhang = !order.nhanhang;

            db.SaveChanges();
            return order.nhanhang;
        }

        public List<OrderViewModel> ListOrdetail(long id)
        {
            var model = db.Orders.Find(id);
            var orde = (from a in db.Products
                        join b in db.OrderDetails
                        on a.ID equals b.ProductID
                        where b.OrderID == id
                        select new
                        {
                            OrderID = b.OrderID,
                            ProductID = b.ProductID,
                            ProductName = a.Name,
                            Quantity = b.Quantity,
                            Price = b.Price
                        }).AsEnumerable().Select(x => new OrderViewModel()
                        {
                            OrderID = x.OrderID,
                            ProductID = x.ProductID,
                            ProductName = x.ProductName,
                            Quantity = x.Quantity,
                            Price = x.Price
                        });
            //return db.OrderDetails.Where(x => x.OrderID == id).ToList();
            return orde.ToList();
        }
        public List<Order> ListAll()
        {
            var model = db.Orders;
            model.Where(x => x.Status == false && x.trahang == false);
            return model.ToList();
        }
        public List<OrderViewModel> SumOrrder()
        {
            var mode = (from a in db.Orders
                       join b in db.OrderDetails
                       on a.ID equals b.OrderID
                       select new
                       {
                           OrderID = b.OrderID,
                           Price = b.Price,
                           CreatedDate = a.CreatedDate,
                           nhanhang = a.nhanhang
                       })
                       .AsEnumerable().Select(x => new OrderViewModel()
                       {
                           OrderID = x.OrderID,
                           Price = x.Price,
                           CreatedDate = x.CreatedDate,
                           nhanhang = x.nhanhang
                       });
            return mode.ToList();
        }
    }
}
