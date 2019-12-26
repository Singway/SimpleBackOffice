using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Operatingtime { get; set; }
        public string UserName { get; set; }
        public string Identity { get; set; }
        public string Requesturl { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public string InputValue { get; set; }
        public string Exception { get; set; }
        public string Loger { get; set; }

    }
}
