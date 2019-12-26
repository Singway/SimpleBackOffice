using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class PswViewModel
    {
        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(8, ErrorMessage = "密码长度不能低于8个字符")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "验证密码不一致")]
        public string ConfirmPassword { get; set; }
    }
}
