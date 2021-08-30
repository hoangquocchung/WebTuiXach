using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method_client
{
    public class BannerView
    {
        MyDB db = null;
        public BannerView()
        {
            db = new MyDB();
        }

        public List<Banner> ListAllBanner()
        {
            return db.Banners.OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
