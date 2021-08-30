using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTuiXach.Models
{
    public class LoginClient
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string password { set; get; }
    }
}