using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class ArticleDao
    {
        MyDB db = null;
        public ArticleDao()
        {
            db = new MyDB();
        }

        public Content ViewDetail(long id)
        {
            return db.Contents.Find(id);
        }


        /* ========================= Admin ===================================== */
        public List<Content> ListAllContent(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Contents.Count();
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public long Create(Content entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                entity.Metatitle = chuyendoi;
            }
            entity.CreatedDate = DateTime.Now;
            entity.ModifiledDate = DateTime.Now;
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Edit(Content entity)
        {
            try
            {
                var model = db.Contents.Find(entity.ID);
                model.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                    entity.Metatitle = chuyendoi;
                }
                model.Description = entity.Description;
                model.Detail = entity.Detail;
                model.CategoryID = entity.CategoryID;
                model.CreatedBy = entity.CreatedBy;
                model.CreatedDate = entity.CreatedDate;
                model.Images = entity.Images;
                model.IsHome = entity.IsHome;
                model.MetaKeywords = entity.MetaKeywords;
                model.ModifiledBy = entity.ModifiledBy;
                model.MetaKeywords = entity.MetaKeywords;
                model.ModifiledDate = DateTime.Now;
                model.Warranty = entity.Warranty;
                model.Status = entity.Status;
                model.IsHome = entity.IsHome;
                model.Tags = entity.Tags;
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
            var ContentID = db.Contents.Find(id);
            db.Contents.Remove(ContentID);
            db.SaveChanges();
            return true;
        }
        public bool ChangeStatus(long id)
        {
            var Content = db.Contents.Find(id);
            Content.Status = !Content.Status;
            db.SaveChanges();
            return Content.Status;
        }
    }
}
