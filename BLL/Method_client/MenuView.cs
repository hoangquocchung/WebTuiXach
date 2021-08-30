using Data.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Method_client
{
    public class MenuView
    {
        MyDB db = null;
        public MenuView()
        {
            db = new MyDB();
        }

        public List<MenuUser> ListAllMenu()
        {
            return db.MenuUsers.OrderBy(x => x.FrameViewID).ToList();
        }
        public MenuUser MenusLink(long id)
        {
            var product = db.Products.Find(id);
            var menu = db.MenuUsers.Find(product.MainMenu);
            return menu;
        }
        public List<MenuUser> MenusLink()
        {
            var menu = db.MenuUsers.OrderByDescending(x =>x.Level).ToList();
            return menu;
        }
    }
}
