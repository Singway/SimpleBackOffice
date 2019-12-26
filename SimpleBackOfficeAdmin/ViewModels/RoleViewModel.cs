using Microsoft.AspNetCore.Mvc;
using SimpleBackOfficeAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="角色名称不能为空"),MaxLength(20)]
        [Remote("VerifyName","Role")]
        public string Name { get; set; }
        [ MaxLength(50)]
        public string Description { get; set; }
        public IdentityRoleV2 Role { get; set; }
        public List<IdentityRoleV2> Roles { get;  set; }
        public List<UserInRole> Users { get; set; }
        public List<DeptInRole> Depts { get; set; }
        public RoleViewModel()
        {
            Depts = new List<DeptInRole>();
            Roles = new List<IdentityRoleV2>();
            Users = new List<UserInRole>();
        }
    }
}
