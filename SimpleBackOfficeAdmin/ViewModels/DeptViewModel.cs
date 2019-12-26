using Microsoft.AspNetCore.Mvc;
using SimpleBackOfficeAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleBackOfficeAdmin.ViewModels
{
    public class DeptViewModel
    {
        public DeptViewModel()
        {
            Departments = new List<Department>();
            Subordinates = new List<string>();
            Department = new Department();
        }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }
        public List<string> Subordinates { get; set; }
        //以下属性几乎是虚设，后期更新

        [Required(ErrorMessage = "部门编码不能为空")]
        [Remote("ConfirmDeptCode", "Department")]
        [MinLength(3, ErrorMessage = "部门编码必须为三位数")]
        public string ConfirmDeptCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
