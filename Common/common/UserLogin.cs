using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string Username { set; get; }
        public string GroupID { set; get; }
    }
}
