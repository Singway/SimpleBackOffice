using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.ViewModels;

namespace SimpleBackOfficeAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly AdminContext context;

        public HomeController(ILoggerFactory logger, AdminContext context)
        {
            this.logger = logger.CreateLogger<HomeController>();
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index() {
            logger.LogWarning("登录成功{LogType}", "Login");
            return View();
        } 
        public IActionResult aaa()
        {
            ViewBag.Tittle = "Simple Back-Office";
            return View();
        }

        [HttpGet]
        public IActionResult LoginLogs()
        {
            var models = new List<LogViewModel>();
            var logs = context.DBLogs.Where(log=>log.LogType=="Login").ToList();
            foreach (var log in logs)
            {
                var model = new LogViewModel
                {
                    Operatingtime = log.Operatingtime,
                    UserName = log.UserName,
                    Identity = log.Identity,
                    Requesturl = log.Requesturl,
                    Method = log.Method,
                    Message = log.Message,
                    Exception = log.Exception
                };
                models.Add(model);
            }
            return View(models);
        }
        [HttpGet]
        public IActionResult OperatingLogs()
        {
            var models = new List<LogViewModel>();
            var logs = context.DBLogs.Where(log => log.LogType == "Operate");
            foreach (var log in logs)
            {
                var model = new LogViewModel
                {
                    Id = log.Id,
                    Operatingtime = log.Operatingtime,
                    UserName = log.UserName,
                    Identity = log.Identity,
                    Requesturl = log.Requesturl,
                    Method = log.Method,
                    Message = log.Message,
                    InputValue = log.CustomProperty
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpGet]
        public IActionResult ErrorLogs()
        {
            var models = new List<LogViewModel>();
            var logs = context.DBLogs.Where(log => log.Exception!=""&& log.Exception != null);
            foreach (var log in logs)
            {
                var model = new LogViewModel
                {
                    Id=log.Id,
                    Operatingtime = log.Operatingtime,
                    UserName = log.UserName,
                    Identity = log.Identity,
                    Loger = log.Logger,
                    Requesturl = log.Requesturl,
                    Method = log.Method,
                    Message = log.Message,
                    Exception = log.Exception
                };
                models.Add(model);
            }
            return View(models);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandle(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    logger.LogError($"产生了错误，路径为{statusCodeResult.OriginalPath}，查询字符串为{statusCodeResult.OriginalQueryString}");
                    ViewBag.ErrorMessage = "抱歉，您访问的页面不存在";
                    break;
            }
            return View("NotFound");
        }
    }
}
