using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class UserInRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool InRole { get; set; }
        public IList<string> InRoles { get; set; }
    }
}
