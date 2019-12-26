using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class DeptInRole
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public bool InRole { get; set; }
        public IEnumerable<string> InRoles { get; set; }
    }
}
