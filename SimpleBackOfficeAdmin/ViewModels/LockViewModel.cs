using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class LockViewModel
    {
        [Required(ErrorMessage = "账号已失效，请重新登录")]
        public string Account { get; set; }

        [Required(ErrorMessage ="请输入密码")]
        public string Password { get; set; }
    }
}
