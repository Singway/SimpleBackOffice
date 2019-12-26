using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Models
{
    public class IdentityUserV2:IdentityUser
    {  
        [Required(ErrorMessage ="城市不能为空")]
        public string City { get; set; }
        [Required(ErrorMessage ="昵称不能为空"),MaxLength(20)]
        public string NickName { get; set; }
        public string Department { get; set; }
        public string DeptCode { get; set; }
        public string Position { get; set; }
        public int JobGrade { get; set; }
        public string Photo { get; set; }
    }
}
