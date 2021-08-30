using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method
{
    public class QAndA
    {
        MyDB db = null;
        public QAndA()
        {
            db = new MyDB();
        }

        public long Create(QandA entity)
        {
            entity.CreateDated = DateTime.Now;

            db.QandAs.Add(entity);
            db.SaveChanges();
            return entity.ID;

        }
    }
}
