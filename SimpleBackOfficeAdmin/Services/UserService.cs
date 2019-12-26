using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.ViewModels;

namespace SimpleBackOfficeAdmin.Services
{
    public class UserService : IUserService
    {
        private readonly AdminContext context;
        private readonly UserManager<IdentityUserV2> userManager;
        private readonly SignInManager<IdentityUserV2> signInManager;
        private readonly ILogger<UserService> logger;
        private readonly IWebHostEnvironment webHost;
        private readonly IDeptManager deptManager;

        public UserService(AdminContext context, UserManager<IdentityUserV2> userManager, SignInManager<IdentityUserV2> signInManager, ILogger<UserService> logger, IWebHostEnvironment webHost,IDeptManager deptManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.webHost = webHost;
            this.deptManager = deptManager;
        }

        public async Task<string> Add(AccViewModel model)
        {
            try
            {
                string errorMessage = null;
                var user = new IdentityUserV2
                {
                    Email = model.RegisterEmail,
                    UserName = model.RegisterName,
                    NickName = model.UserV2.NickName,
                    City = model.UserV2.City,
                    Position = model.UserV2.Position
                };
                string[] deptInfo = model.Department.Split('，');
                user.Department = deptInfo[1];
                user.DeptCode = deptInfo[0].Trim('，');
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    logger.LogWarning("添加用户{LogType}{CustomProperty}", "Operate", user.UserName);
                    if (user.DeptCode != "0")
                    {
                        int deptId = deptManager.GetDeptId(user.DeptCode);
                        var ids = await deptManager.GetRolesIdAsync(deptId);
                        foreach (var id in ids)
                        {
                            context.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = id });
                        }
                        context.SaveChanges();
                    }
                    return errorMessage;
                }
                foreach (var error in result.Errors)
                {
                    errorMessage += error.Description + "\r\n";
                }
                logger.LogWarning("添加用户失败{LogType}{CustomProperty}", "Operate", errorMessage);
                return errorMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    await userManager.DeleteAsync(user);
                    if (user.Photo != null)
                    {
                        string oldPath = Path.Combine(webHost.WebRootPath, "images/faces", user.Photo);
                        File.Delete(oldPath);
                    }
                    logger.LogWarning("删除账户{LogType}{CustomProperty}", "Operate", "Id:" + id);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> EditPassword(PersonalViewModel model)
        {
            try
            {
                var user = await userManager.FindByIdAsync(model.Id);
                var result = await userManager.ChangePasswordAsync(user, model.Psw.CurrentPassword, model.Psw.NewPassword);
                if (result.Succeeded)
                {
                    logger.LogWarning("修改密码{LogType}", "Operate");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> EditPersonalInfo(PersonalViewModel model)
        {
            try
            {
                var user = await userManager.FindByIdAsync(model.Id);
                //更新头像
                if (model.PhotoFile != null)
                {
                    string uniqueFileName;
                    string fileFolder = Path.Combine(webHost.WebRootPath, "images/faces");
                    uniqueFileName = user.UserName + "_" + model.PhotoFile.FileName;
                    if (user.Photo != null)
                    {
                        string oldPath = Path.Combine(webHost.WebRootPath, "images/faces", user.Photo);
                        File.Delete(oldPath);
                    }
                    user.Photo = uniqueFileName;
                    string filePath = Path.Combine(fileFolder, uniqueFileName);
                    using FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    model.PhotoFile.CopyTo(fileStream);
                }
                user.NickName = model.NickName;
                user.Email = model.EditEmail;
                user.City = model.City;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    logger.LogWarning("修改个人信息{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model));
                }
                else
                {
                    string errors = null;
                    foreach (var error in result.Errors)
                    {
                        errors += error.Description + ";";
                    }
                    logger.LogWarning("修改个人信息失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(errors));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> EditUser(AccViewModel model)
        {
            try
            {
                string errorMessage = null;
                var user = await userManager.FindByIdAsync(model.UserV2.Id);
                if (user == null)
                {
                    errorMessage = "您操作的用户已不存在";
                    return errorMessage;
                }
                string oldDeptCode = user.DeptCode;
                string[] deptInfo = model.Department.Split('，');
                user.Department = deptInfo[1];
                user.DeptCode = deptInfo[0].Trim('，');
                user.Position = model.UserV2.Position;
                user.NickName = model.UserV2.NickName;
                user.City = model.UserV2.City;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                    if (oldDeptCode != "0")
                    {
                        int deptId = deptManager.GetDeptId(oldDeptCode);
                        var ids = await deptManager.GetRolesIdAsync(deptId);
                        foreach (var id in ids)
                        {
                            var ur= context.UserRoles.FirstOrDefault(ur => ur.RoleId == id && ur.UserId == user.Id);
                            if (ur!=null)
                            {
                                context.UserRoles.Remove(new IdentityUserRole<string> { UserId = user.Id, RoleId = id });
                            }
                        }
                    }
                    if (user.DeptCode!="0")
                    {
                        int deptId = deptManager.GetDeptId(user.DeptCode);
                        var ids = await deptManager.GetRolesIdAsync(deptId);
                        foreach (var id in ids)
                        {
                            var ur = context.UserRoles.FirstOrDefault(ur => ur.RoleId == id && ur.UserId == user.Id);
                            if (ur == null)
                            {
                                context.UserRoles.Add(new IdentityUserRole<string> { UserId = user.Id, RoleId = id });
                            }
                        }
                    }
                    context.SaveChanges();
                    logger.LogWarning("修改用户信息{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model));
                    return errorMessage;
                }
                foreach (var error in result.Errors)
                {
                    errorMessage += error.Description + ";";
                }
                logger.LogWarning("修改用户信息失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(errorMessage));
                return errorMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AccViewModel Index()
        {
            try
            {
                var users = userManager.Users.ToList();
                var departments = context.Departments.ToList();
                AccViewModel model = new AccViewModel(departments)
                {
                    Users = users
                };
                logger.LogWarning("读取账户");
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.LoginAccount);
            if (user == null)
            {
                user = await userManager.FindByEmailAsync(model.LoginAccount);
            }
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.LoginPassword, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public PersonalViewModel PersonalCenter(IdentityUserV2 user)
        {
            try
            {
                var model = new PersonalViewModel
                {
                    Id = user.Id,
                    EditEmail = user.Email,
                    NickName = user.NickName,
                    City = user.City
                };
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Register(LoginModel model)
        {
            string errorMessage = null;
            var user = new IdentityUserV2
            {
                Email = model.RegisterEmail,
                UserName = model.RegisterName,
                NickName = model.NickName,
                City = model.City
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                logger.LogWarning("注册账户{LogType}" + model.RegisterName, "Login");
                return errorMessage;
            }
            foreach (var error in result.Errors)
            {
                errorMessage+= error.Description;
                logger.LogWarning("注册账户失败{LogType}}{CustomProperty}" , "Login",JsonConvert.SerializeObject(errorMessage) + model.RegisterName);
            }
            return errorMessage;
        }

        public async Task SignOut()
        {
            logger.LogWarning("退出登录{LogType}", "Login");
            await signInManager.SignOutAsync();
            return;
        }

        public async Task Lock(string userName)
        {
            await signInManager.SignOutAsync();
        }

        public async Task<string> DisLock(string psw, string name)
        {
            try
            {
                var user = await userManager.FindByNameAsync(name);
                if (user == null)
                {
                    return "用户已失效，请重新登录";
                }
                var result = await userManager.CheckPasswordAsync(user, psw);
                if (!result)
                {
                    return "密码错误";
                }
                await signInManager.SignInAsync(user, false);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
