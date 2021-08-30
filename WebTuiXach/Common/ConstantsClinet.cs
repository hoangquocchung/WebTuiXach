using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTuiXach.Common
{
    public static class ConstantsClinet
    {
        public static string USER = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";

        public static string CurrentCulture { set; get; }

        public static string MEMBER_GROUP = "MEMBER";
        public static string ADMIN_GROUP = "ADMIN";
        public static string MOD_GROUP = "MOD";
    }
}