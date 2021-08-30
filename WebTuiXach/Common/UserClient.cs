using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTuiXach
{
    [Serializable]
    public class UserClient
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
    }
}