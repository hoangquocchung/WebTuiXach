using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class ProductDao
    {
        MyDB db = null;
        public ProductDao()
        {
            db = new MyDB();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }


        /* ========================= Admin ===================================== */
        public List<Product> ListAllProduct(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Count();
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public long Create(Product entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                entity.Metatitle = chuyendoi;
            }
            entity.CreatedDate = DateTime.Now;
            entity.ModifiledDate = DateTime.Now;
            entity.ViewConut = 0;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Edit(Product entity)
        {
            try
            {
                var model = db.Products.Find(entity.ID);
                model.Name = entity.Name;
                model.Code = entity.Code;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                    entity.Metatitle = chuyendoi;
                }
                model.Description = entity.Description;
                model.Detail = entity.Detail;
                model.CategoryID = entity.CategoryID;
                model.MainMenu = entity.MainMenu;
                model.CreatedBy = entity.CreatedBy;
                model.Images = entity.Images;
                model.MoreImages = entity.MoreImages;
                model.IncludeVAT = entity.IncludeVAT;
                model.IsHome = entity.IsHome;
                model.MetaKeywords = entity.MetaKeywords;
                model.ModifiledBy = entity.ModifiledBy;
                model.ModifiledDate = DateTime.Now;
                model.Price = entity.Price;
                model.PromotionPrice = entity.PromotionPrice;
                model.Quantity = entity.Quantity;
                model.Warranty = entity.Warranty;
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
            var ProductID = db.Products.Find(id);
            db.Products.Remove(ProductID);
            db.SaveChanges();
            return true;
        }
        public bool ChangeStatus(long id)
        {
            var Product = db.Products.Find(id);
            Product.Status = !Product.Status;
            db.SaveChanges();
            return Product.Status;
        }
        public long UpdateImage(Product entity, string images)
        {

            entity.MoreImages = images;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //public void UpdateImage(long id, string images)
        //{
        //    var product = db.Products.Find(id);
        //    product.MoreImages = images;
        //    db.SaveChanges();
        //}
        public List<Product> listAll()
        {
            return db.Products.ToList();
        }

        public List<Product> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.Name == keyword).Count();
            var model = db.Products.Where(x => x.Name.Contains(keyword)).OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
