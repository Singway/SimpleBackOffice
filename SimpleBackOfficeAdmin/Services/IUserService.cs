using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.ViewModels;

namespace SimpleBackOfficeAdmin.Services
{
    public interface IUserService
    {
        public AccViewModel Index();
        public PersonalViewModel PersonalCenter(IdentityUserV2 user);
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<IdentityResult> EditPersonalInfo(PersonalViewModel model);
        public Task<IdentityResult> EditPassword(PersonalViewModel model);
        public Task<string> Register(LoginModel model);
        public Task<bool> Login(LoginModel model);
        public Task<string> EditUser(AccViewModel model);
        public Task Delete(string id);
        public Task<string> Add(AccViewModel model);
        public Task SignOut();
        public Task Lock(string userName);
        public Task<string> DisLock(string psw, string name);
    }
}
