using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Models
{
    public class IdentityRoleV2:IdentityRole
    {
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
