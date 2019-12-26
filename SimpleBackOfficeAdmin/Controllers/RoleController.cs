using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.Services;
using SimpleBackOfficeAdmin.ViewModels;

namespace SimpleBackOfficeAdmin.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRoleV2> roleManager;
        private readonly IRoleService roleService;

        public RoleController(RoleManager<IdentityRoleV2> roleManager, IRoleService roleService)
        {
            this.roleManager = roleManager;
            this.roleService = roleService;
        }
        public async Task<IActionResult> Index(string errorMessage = null,string errorId=null)
        {
            var model = await roleService.Index();
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.Id = errorId;
            return View(model);
        }

        /// <summary>
        /// 修改角色里面的用户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleName">被修改角色名字</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUsersInRole(RoleViewModel model, string roleName)
        {
            var result = await roleService.EditUsersInRole(model, roleName);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), new { errorMessage = result });
        }

        /// <summary>
        /// 修改角色里面的部门，自动修改对应部门的用户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditDeptsInRole(RoleViewModel model, string roleId)
        {
            var result =await roleService.EditDeptsInRole(model, roleId);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
                    return RedirectToAction(nameof(Index), new { errorMessage = result.Error });
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel model)
        {
            var result = await roleService.Add(model);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), new { errorMessage = result });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await roleService.Delete(id);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), new { errorMessage = result });
        }

        //修改角色信息
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleViewModel model)
        {
            var result = await roleService.EditRole(model);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), new { errorMessage = result ,errorId=model.Role.Id});
        }

        public async Task<JsonResult> VerifyName(string name)
        {
            var role = await roleManager.FindByNameAsync(name);
            if (role == null)
            {
                return Json(true);
            }
            return Json($"{name}已被使用");
        }
    }
}
