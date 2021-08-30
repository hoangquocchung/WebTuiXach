using Common.common;
using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method_client
{
    public class UserV
    {
        MyDB db = null;
        public UserV()
        {
            db = new MyDB();
        }
        public User GetByID(string username)
        {
            return db.Users.SingleOrDefault(x => x.Username == username);

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
                    if (res.Group == ConstantsClinet.MEMBER)
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
    }
}
