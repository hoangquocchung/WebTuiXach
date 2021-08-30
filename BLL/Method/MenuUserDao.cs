using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class MenuUserDao
    {
        MyDB db = null;
        public MenuUserDao()
        {
            db = new MyDB();
        }

        public MenuUser ViewDetail(long id)
        {
            return db.MenuUsers.Find(id);
        }

        public List<MenuUser> ListAllMenuUser(string searchString, ref int totalRecord, int pageIndex = 2, int pageSize = 10)
        {
            totalRecord = db.MenuUsers.Count();
            IQueryable<MenuUser> model = db.MenuUsers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public long Create(MenuUser entity)
        {
            if (!string.IsNullOrEmpty(entity.Name))
            {
                var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                entity.Url = chuyendoi;
            }
            entity.Type = 1;
            entity.FrameViewID = 2;
            db.MenuUsers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public long CreateLink(Link entity)
        {
            
            if (!string.IsNullOrEmpty(entity.Name))
            {
                var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                entity.Slug = chuyendoi;
            }
            entity.Type = "product";
            db.Links.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Edit(MenuUser entity, Link lik)
        {
            try
            {
                var model = db.MenuUsers.Find(entity.ID);
                var sl = db.Links.Find(lik.ID);
                model.Name = entity.Name;
                model.SeoTitle = entity.SeoTitle;
                model.Type = 1;
                model.FrameViewID = 2;
                model.Level = entity.Level;
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    var chuyendoi = CommonConstants.utf8Convert1(entity.Name);
                    model.Url = chuyendoi;
                    sl.Slug = chuyendoi;
                }
                model.ParentID = entity.ParentID;
                model.Satus = entity.Satus;

                sl.TableId = entity.ID;
                sl.Name = entity.Name;
                sl.Type = "product";
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //public bool EditLink(long id, string )
        public bool Delete(long id)
        {
            var MenuID = db.MenuUsers.Find(id);
            var Link = db.Links.Find(id);
            db.MenuUsers.Remove(MenuID);
            db.Links.Remove(Link);
            db.SaveChanges();
            return true;
        }
        public bool ChangeStatus(long id)
        {
            var menuuser = db.MenuUsers.Find(id);
            menuuser.Satus = !menuuser.Satus;
            db.SaveChanges();
            return menuuser.Satus;
        }
        public List<MenuUser> ListAllSubmenu()
        {
            return db.MenuUsers.Where(x => x.Satus == true).ToList();
        }

    }
}
