using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBackOfficeAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.ViewModels
{
    public class PersonalViewModel
    {
        public string Id { get; set; }
        public IFormFile PhotoFile { get; set; }
        public string NewPhoto { get; set; }

        [Required(ErrorMessage = "邮箱不能为空")]
        [EmailAddress(ErrorMessage ="邮箱格式不正确")]
        [Remote("EditEmail", "Account")]
        public string EditEmail { get; set; }

        [Required(ErrorMessage = "城市不能为空")]
        public string City { get; set; }

        [Required(ErrorMessage = "昵称不能为空"), MaxLength(20)]
        public string NickName { get; set; }
        public PswViewModel Psw { get; set; }
    }
}
