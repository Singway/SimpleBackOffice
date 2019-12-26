using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public  class LoginModel
    {
        [Required(ErrorMessage = "请输入账号")]
        public string LoginAccount { get; set; }

        [Required(ErrorMessage ="请输入密码")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        [Remote("VerifyEmail", "Account")]
        public string RegisterEmail { get; set; }

        [Required(ErrorMessage = "登录名不能为空")]
        [Remote("VerifyName", "Account")]
        public string RegisterName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(8, ErrorMessage = "密码长度不能低于8个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "验证密码不一致")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "城市不能为空")]
        public string City { get; set; }

        [Required(ErrorMessage = "昵称不能为空"), MaxLength(20)]
        public string NickName { get; set; }
    }
}
