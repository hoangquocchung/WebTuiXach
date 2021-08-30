using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class AdvDao
    {
        MyDB db = null;
        public AdvDao()
        {
            db = new MyDB();
        }

        public ADV ViewDetail(long id)
        {
            return db.ADVs.Find(id);
        }
        /* ========================= Admin ===================================== */
        public List<ADV> ListAllADV(string searchString, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.ADVs.Count();
            IQueryable<ADV> model = db.ADVs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public long Create(ADV entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                entity.URL = chuyendoi;
            }
            entity.CreatedDate = DateTime.Now;
            entity.ModifiledDate = DateTime.Now;
            db.ADVs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Edit(ADV entity)
        {
            try
            {
                var model = db.ADVs.Find(entity.ID);
                model.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                    entity.URL = chuyendoi;
                }
                model.ImageID = entity.ImageID;
                model.Description = entity.Description;
                model.CreatedBy = entity.CreatedBy;
                model.MetaKeywords = entity.MetaKeywords;
                model.ModifiledBy = entity.ModifiledBy;
                model.ModifiledDate = DateTime.Now;
                model.TypeOfAdvID = entity.TypeOfAdvID;
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
            var ADVID = db.ADVs.Find(id);
            db.ADVs.Remove(ADVID);
            db.SaveChanges();
            return true;
        }
        public bool ChangeStatus(long id)
        {
            var ADV = db.ADVs.Find(id);
            ADV.Status = !ADV.Status;
            db.SaveChanges();
            return ADV.Status;
        }
    }
}
