using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class ContactDao
    {
        MyDB db = null;
        public ContactDao()
        {
            db = new MyDB();
        }
        public Contact GetActiveContac()
        {
            return db.Contacts.Single(x => x.statust == true);
        }
        public Contact getView()
        {
            return db.Contacts.First();
        }
        public Contact view(long id)
        {
            return db.Contacts.Find(id);
        }
        public bool Edit(Contact entity) {
            var model = db.Contacts.Find(entity);
            model.Content = entity.Content;
            db.SaveChanges();
            return true;
        }
    }
}
