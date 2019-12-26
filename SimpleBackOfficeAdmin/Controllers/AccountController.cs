using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SimpleBackOfficeAdmin.Services;
using Microsoft.Extensions.Logging;
using NLog;
using Newtonsoft.Json;
using System.Security.Claims;

namespace SimpleBackOfficeAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUserV2> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly IUserService userService;

        public AccountController(UserManager<IdentityUserV2> userManager,ILogger<AccountController> logger, IUserService userService)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.userService = userService;
        }

        /// <summary>
        /// 用户主界面
        /// </summary>
        /// <param name="errorMessage">错误信息，可空</param>
        /// <returns></returns>
        public IActionResult Index(string errorMessage = null,string errorId=null)
        {
            var model = userService.Index();
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.Id = errorId;
            return View(model);
        }

        public async Task<IActionResult> Lock()
        {
            ViewBag.UserName = User.Identity.Name;
            await userService.SignOut();
            return View(new LockViewModel{Account= User.Identity.Name });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Lock(LockViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.DisLock(model.Password, model.Account);
                if (result == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result);
            }
            return View(model);
        }

        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> PersonalCenter()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var model = userService.PersonalCenter(user);
            return View(model);
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditInfo(PersonalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.EditPersonalInfo(model);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(PersonalCenter));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("PersonalCenter", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(PersonalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.EditPassword(model);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(PersonalCenter));
                }
                ModelState.AddModelError("", "密码错误");
            }
            return View(nameof(PersonalCenter), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        //注册用户
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.Register(model);
                if (result == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Index", new { errorMessage = result });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await userService.SignOut();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            var result = await userService.Login(model);
            if (result)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    logger.LogWarning("登录重定向到{LogType}" + returnUrl, "Login");
                    return LocalRedirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            logger.LogWarning("登录失败{LogType}{CustomProperty}", "Login", JsonConvert.SerializeObject(model));
            ViewBag.ErrorMessage = "抱歉，您输入的账号或密码有误，请重新输入";
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUser(AccViewModel model)
        {
            var result = await userService.EditUser( model);
            if (result==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", new { errorMessage=result,errorId= model.UserV2.Id });
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AccViewModel model)
        {
            var result = await userService.Add(model);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", new { errorMessage = result });
        }

        [HttpGet]
        public ViewResult Deny() => View();

        [AllowAnonymous]
        public async Task<JsonResult> VerifyEmail(string registerEmail) => await Verify(registerEmail);

        [AllowAnonymous]
        public async Task<JsonResult> VerifyName(string registerName) => await Verify(registerName);

        /// <summary>
        /// 修改邮箱可继续使用原来的
        /// </summary>
        /// <param name="editEmail">验证邮箱</param>
        /// <returns></returns>
        public async Task<JsonResult> EditEmailAsync(string editEmail)
        {
            var user = await userManager.FindByEmailAsync(editEmail);
            if (user == null)
            {
                return Json(true);
            }
            if (user.UserName == User.Identity.Name)
            {
                return Json(true);
            }
            return Json($"{editEmail} 已被注册");
        }

        [AllowAnonymous]
        /// <summary>
        /// 验证注册的邮箱和账号是否已被使用
        /// </summary>
        /// <param name="verifyInfo">验证信息</param>
        /// <returns></returns>
        private async Task<JsonResult> Verify(string verifyInfo)
        {
            var user1 = await userManager.FindByEmailAsync(verifyInfo);
            var user2 = await userManager.FindByNameAsync(verifyInfo);
            if (user1 == null && user2 == null)
            {
                return Json(true);
            }
            return Json($"{verifyInfo} 已被注册");
        }
    }
}
