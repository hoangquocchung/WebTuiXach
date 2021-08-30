using Data.FE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common.common;

namespace BLL.Method
{
    public class UserDao
    {
        MyDB db = null;
        public UserDao()
        {
            db = new MyDB();
        }
        public int Login(string UserName, string passWord, bool isLoginAdmin = false)
        {
            var res = db.Users.SingleOrDefault(x => x.Username == UserName);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (res.Group == CommonConstants.ADMIN_GROUP || res.Group == CommonConstants.MOD_GROUP)
                    {
                        if (res.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (res.Password == passWord)
                            {
                                return 1;
                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                    else
                    {
                        return -3;
                    }

                }
                else
                {
                    if (res.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (res.Password == passWord)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                }
            }

        }
        public List<string> GetListCredential(string username)
        {
            var user = db.Users.Single(x => x.Username == username);
            var data = (from a in db.Credentials
                        join b in db.UserGroups
                        on a.UserGroupID equals b.ID
                        join c in db.Roles
                        on a.RoleID equals c.ID
                        where b.ID == user.Group
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID

                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();
        }
        public User GetByID(string username)
        {
            return db.Users.SingleOrDefault(x => x.Username == username);

        }


        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.Username == entity.Username);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }

        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Addess = entity.Addess;
                user.Email = entity.Email;
                user.ModifiledBy = entity.ModifiledBy;
                user.ModifiledDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.Username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
