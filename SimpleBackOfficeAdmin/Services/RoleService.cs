using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.ViewModels;

namespace SimpleBackOfficeAdmin.Services
{
    public class RoleService : IRoleService
    {
        private readonly AdminContext context;
        private readonly RoleManager<IdentityRoleV2> roleManager;
        private readonly UserManager<IdentityUserV2> userManager;
        private readonly IDeptManager deptManager;
        private readonly ILogger<RoleService> logger;

        public RoleService(AdminContext context, RoleManager<IdentityRoleV2> roleManager,UserManager<IdentityUserV2> userManager,IDeptManager deptManager,  ILogger<RoleService> logger)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.deptManager = deptManager;
            this.logger = logger;
        }
        public async Task<RoleViewModel> Index()
        {
            var model = new RoleViewModel();
            foreach (var user in userManager.Users)
            {
                model.Users.Add(new UserInRole
                { Id = user.Id, Name = user.UserName, InRoles = await userManager.GetRolesAsync(user) });
            }
            foreach (var dept in context.Departments)
            {
                model.Depts.Add(new DeptInRole { Id = dept.Id, DeptName = dept.DeptName, InRoles = await deptManager.GetRolesIdAsync(dept.Id) });
            }
            model.Roles = roleManager.Roles.ToList();
            logger.LogWarning("查看角色{LogType}", "Operate");
            return model;
        }
        public async Task<string> EditUsersInRole(RoleViewModel model, string roleName)
        {
            string errorMessage = null;
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                errorMessage = $"找不到角色名为{roleName}的角色，请确认";
                logger.LogWarning("修改角色用户失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model.Users) + $"错误原因：{errorMessage}");
                return errorMessage;
            }
            foreach (var item in model.Users)
            {
                var user = await userManager.FindByIdAsync(item.Id);
                bool isInRole = await userManager.IsInRoleAsync(user, roleName);
                IdentityResult result = null;
                if (isInRole && !item.InRole)
                {
                    result = await userManager.RemoveFromRoleAsync(user, roleName);
                }
                else if (!isInRole && item.InRole)
                {
                    result = await userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    continue;
                }
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        errorMessage += error.Description;
                    }
                    logger.LogWarning("修改角色用户失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model.Users) + $"错误原因：{errorMessage}");
                }
            }
            logger.LogWarning("修改角色用户{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model.Users));
            return errorMessage;
        }

        public async Task<DeptResult> EditDeptsInRole(RoleViewModel model, string roleId)
        {
            var deptResult=new DeptResult { Succeeded = false };
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                deptResult.Error = "找不到角色，请确认";
                logger.LogWarning("修改角色部门失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model.Depts) + $"错误原因：{deptResult.Error}");
                return deptResult;
            }
            foreach (var item in model.Depts)
            {
                bool isInRole = await deptManager.IsInRoleAsync(item.Id, roleId);
                var users = userManager.Users.Where(user => user.Department == item.DeptName).ToList();
                if (isInRole && !item.InRole)
                {
                    await userManager.RemoveUsersFromRoleAsync(users, role.Name);
                    deptResult = await deptManager.RemoveFromRoleAsync(item.Id, roleId);
                }
                else if (!isInRole && item.InRole)
                {
                    await userManager.AddUsersToRoleAsync(users, role.Name);
                    deptResult = await deptManager.AddToRoleAsync(item.Id, roleId);
                }
                else
                {
                    continue;
                }
                if (!deptResult.Succeeded)
                {
                    logger.LogWarning("修改角色部门失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model.Depts) + $"错误原因：{deptResult.Error}");
                    return deptResult;
                }
            }
            logger.LogWarning("修改角色部门{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(model.Depts)); 
            return deptResult;
        }
        public async Task<string> Add(RoleViewModel model)
        {
            string errorMessage = null;
            var role = new IdentityRoleV2
            {
                Name = model.Name,
                Description = model.Description
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                logger.LogWarning("添加角色{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(role));
                return errorMessage;
            }
            foreach (var error in result.Errors)
            {
                errorMessage += error.Description + "\r\n";
            }
            logger.LogWarning("添加角色失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(role)+ $"错误原因：{errorMessage}");
            return errorMessage;
        }

        public async Task<string> Delete(string id)
        {
            string errorMessage = null;
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                errorMessage = "抱歉，找不到该角色";
                logger.LogWarning("删除角色失败{LogType}{CustomProperty}", "Operate", id);
                return errorMessage;
            }
            if (role.Name == "admin"|| role.Name == "default")
            {
                errorMessage = "系统管理角色禁止删除";
                logger.LogWarning("删除角色失败{LogType}{CustomProperty}", "Operate", "用户试图删除系统默认角色");
                return errorMessage;
            }
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                logger.LogWarning("删除角色{LogType}{CustomProperty}", "Operate", "Id：" + id);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errorMessage += error.Description;
                }
                logger.LogWarning("删除角色失败{LogType}{CustomProperty}", "Operate", id);
            }
            return errorMessage;
        }

        public async Task<string> EditRole(RoleViewModel model)
        {
            string errorMessage = null; 
            var role = await roleManager.FindByIdAsync(model.Role.Id);
            if (model.Role.Name != role.Name)
            {
                var roles = roleManager.Roles.Where(ro => ro.Name == model.Role.Name);
                if (roles.Count() > 0)
                {
                    return model.Role.Name + "已被使用";
                }
                role.Name = model.Role.Name;
            }
            role.Description = model.Role.Description;
            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                logger.LogWarning("修改角色信息{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(role));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errorMessage += error.Description;
                }
                logger.LogWarning("修改角色信息失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(role) + $"失败原因：{errorMessage}");
            }
            return errorMessage;
        }
    }
}
