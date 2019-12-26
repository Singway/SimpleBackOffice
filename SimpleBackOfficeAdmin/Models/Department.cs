using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "部门编码不能为空")]
        [MinLength(3, ErrorMessage = "部门编码必须为三位数")]
        public  string  DeptCode{ get; set; }
        [Required(ErrorMessage = "部门名称不能为空")]
        [MaxLength(30)]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "上述机构不能为空")]
        //从属部门代号，0代表顶级父层
        public string Subordinate { get; set; }
        [MaxLength(100)]
        public string  Description { get; set; }
    }
}
