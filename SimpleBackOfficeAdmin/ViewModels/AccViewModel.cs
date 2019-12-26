using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBackOfficeAdmin.Models;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class AccViewModel
    {
        public AccViewModel(List<Department> departments)
        {
            Subordinates = new List<string>();
            foreach (var dept in departments)
            {
                string sub = $"{dept.DeptCode}，{dept.DeptName}";
                Subordinates.Add(sub);
            }
            Positions = new List<string>();
            Positions.Add("主管");
            Positions.Add("经理");
            Positions.Add("员工");
            Positions.Add("行政");
        }
        public AccViewModel()
        {

        }
        public List<string> Subordinates { get; }
        public List<IdentityUserV2> Users { get; set; }
        public IdentityUserV2 UserV2 { get; set; }
        public string Department { get; set; }
        public List<string> Positions { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        [Remote("VerifyEmail", "Account")]
        public string RegisterEmail { get; set; }

        [Required(ErrorMessage = "登录名不能为空")]
        [Remote("VerifyName", "Account")]
        public string RegisterName { get; set; }
        [Required(ErrorMessage = "密码不能未空")]
        [MinLength(8, ErrorMessage = "密码长度不能低于8个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "验证密码不一致")]
        public string ConfirmPassword { get; set; }


    }
}
