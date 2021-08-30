using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class ProductCategoryDao
    {
        MyDB db = null;
        public ProductCategoryDao()
        {
            db = new MyDB();
        }
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        //Admin
        public List<ProductCategory> ListAllProductCate(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.ProductCategories.Count();
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.Where(x => x.ParenID != null).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public long Create(ProductCategory entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                entity.Metatitle = chuyendoi;
            }
            entity.CreatedDate = DateTime.Now;
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Edit(ProductCategory entity)
        {
            try
            {
                var model = db.ProductCategories.Find(entity.ID);
                model.Name = entity.Name;
                model.CreatedDate = DateTime.Now;
                model.DisplayOrder = entity.DisplayOrder;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                    model.Metatitle = chuyendoi;
                }
                model.ParenID = entity.ParenID;
                model.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var Productcategori = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(Productcategori);
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
