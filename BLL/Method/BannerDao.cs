using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class BannerDao
    {
        MyDB db = null;
        public BannerDao()
        {
            db = new MyDB();
        }

        public Banner ViewDetail(long id)
        {
            return db.Banners.Find(id);
        }
        public List<Banner> ListAllBanner(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Banners.Count();
            IQueryable<Banner> model = db.Banners;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public long Create(Banner entity)
        {
            db.Banners.Add(entity);
            entity.CreatedDate = DateTime.Now;
            db.SaveChanges();
            return entity.ID;
        }
        public bool Edit(Banner entity)
        {
            try
            {
                var model = db.Banners.Find(entity.ID);
                model.Name = entity.Name;
                model.TypeOfAdvID = entity.TypeOfAdvID;
                model.CreatedBy = entity.CreatedBy;
                model.ImageID = model.ImageID;
                model.ModifiledDate = entity.ModifiledDate;
                model.URL = entity.URL;
                model.ModifiledBy = entity.ModifiledBy;
                model.MetaKeywords = entity.MetaKeywords;
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
            var MenuID = db.Banners.Find(id);
            db.Banners.Remove(MenuID);
            db.SaveChanges();
            return true;
        }
        public bool ChangeStatus(long id)
        {
            var Banner = db.Banners.Find(id);
            Banner.Status = !Banner.Status;
            db.SaveChanges();
            return Banner.Status;
        }
        public List<Banner> ListAllSubmenu()
        {
            return db.Banners.Where(x => x.Status == true).ToList();
        }
        
    }
}
