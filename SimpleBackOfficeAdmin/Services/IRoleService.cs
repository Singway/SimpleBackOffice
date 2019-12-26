using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBackOfficeAdmin.ViewModels;

namespace SimpleBackOfficeAdmin.Services
{
    public interface IRoleService
    {
        public Task<RoleViewModel> Index();
        /// <summary>
        /// 修改角色用户成功返回null,如若失败返回错误信息
        /// </summary>
        /// <returns></returns>
        public Task<string> EditUsersInRole(RoleViewModel model, string roleName);
        /// <summary>
        /// 修改角色部门
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Task<DeptResult> EditDeptsInRole(RoleViewModel model, string roleId);
        /// <summary>
        /// 添加角色,成功返回null,如若失败返回错误信息
        /// </summary>
        /// <returns></returns>
        public Task<string> Add(RoleViewModel model);
        /// <summary>
        /// 删除角色,成功返回null,如若失败返回错误信息
        /// </summary>
        /// <returns></returns>
        public Task<string> Delete(string id);
        /// <summary>
        /// 修改角色,成功返回null,如若失败返回错误信息
        /// </summary>
        /// <returns></returns>
        public Task<string> EditRole(RoleViewModel model);
    }
}
