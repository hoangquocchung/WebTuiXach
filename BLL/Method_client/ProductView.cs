using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method_client
{
    public class ProductView
    {
        MyDB db = null;
        public ProductView()
        {
            db = new MyDB();
        }

        public List<Product> ListAllProdcut(int top)
        {
            return db.Products.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListByProductCate(long cateID,ref long totalRecord, int top)
        {
            totalRecord = db.Products.Where(x => x.MainMenu == cateID).Count();
            var model = db.Products.Where(x => x.MainMenu == cateID && x.Status == true).Take(top);
            return model.ToList();
            
        }

        //public List<Product> ListByProductCate2(long cateID, ref long totalRecord, int top)
        //{
        //    var product = new Product();
        //    var menu = db.MenuUsers.Find(cateID);
        //    string a = "";
        //     a = product.CategoryID;
        //    string[] mang;
        //    mang = a.Split(',');
        //    var model = db.Products;
        //    for(int i = 0; i < mang.Length; i++)
        //    {
        //        menu.ID = i;
        //        totalRecord = db.Products.Where(x => x.MainMenu == cateID).Count();

        //    }

        //    //
        //    //var model = db.Products.Where(x => x.MainMenu == cateID && x.Status == true).Take(top);
        //    return model.ToList();

        //}

        public List<Product> productrelate(long id,int top)
        {
            var product = db.Products.Find(id);
            var model = db.Products.Where(x => x.MainMenu == product.MainMenu).Take(top);
            return model.ToList();
        }

        public bool Viewcount(long id)
        {
            var model = db.Products.Find(id);
            model.ViewConut = model.ViewConut + 1;
            db.SaveChanges();
            return true;
        }

    }
}
