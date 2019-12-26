using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.Services;
using SimpleBackOfficeAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AdminContext context;
        private readonly ILogger<DepartmentController> logger;
        private readonly IDeptManager deptManager;

        public DepartmentController(AdminContext context,ILogger<DepartmentController> logger,IDeptManager deptManager)
        {
            this.context = context;
            this.logger = logger;
            this.deptManager = deptManager;
        }

        public ViewResult Index(Department errorModel = null)
        {
            if (errorModel.DeptCode != null)
            {
                ViewBag.ErrorMessage = errorModel.DeptCode + "已被使用";
                ViewBag.Id = errorModel.Id;
            }
            var model = deptManager.Index();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(DeptViewModel model)
        {
            if (ModelState.IsValid)
            {
                deptManager.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            deptManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(DeptViewModel model)
        {
            var result = deptManager.Edit(model);
            if (!result)
            {
                return RedirectToAction(nameof(Index), model.Department);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ConfirmDeptCode(string confirmDeptCode)
        {
            var result = context.Departments.Where(dept => dept.DeptCode == confirmDeptCode);
            if (result.Count() == 0)
            {
                return Json(true);
            }
            return Json($"{confirmDeptCode}已经被使用");
        }
    }
}
