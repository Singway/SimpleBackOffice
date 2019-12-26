using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Models
{
    public class DeptRole
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public string RoleId { get; set; }
    }
}
