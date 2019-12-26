using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.Services;
using SimpleBackOfficeAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleBackOfficeAdmin.Services
{
    //模拟UserManager的Dept操作类，功能类似
    public class DeptManager:IDeptManager
    {
        private readonly AdminContext context;
        private readonly ILogger<DeptManager> logger;

        public IEnumerable <Department> Departments { get; set; }

        public DeptManager(AdminContext context, ILogger<DeptManager> logger)
        {
            this.context = context;
            this.logger = logger;
            Departments = context.Departments;
        }


        public DeptViewModel Index(Department errorModel = null)
        {
            var model = new DeptViewModel();
            model.Departments = Departments.ToList();
            GetSubordinates(model);
            logger.LogWarning("读取部门信息{LogType}", "Operate");
            return model;
        }
        /// <summary>
        /// 赋值VM中部门list
        /// </summary>
        /// <param name="model">部门的ViewModel</param>
        private static void GetSubordinates(DeptViewModel model)
        {
            var deptcodes = model.Departments.Select(dept => new { dept.DeptCode, dept.DeptName });
            model.Subordinates.Add("0,顶层部门");
            foreach (var deptcode in deptcodes)
            {
                model.Subordinates.Add($"{deptcode.DeptCode},{deptcode.DeptName}");
            }
        }
        public void Create(DeptViewModel model)
        {
            var dept = model.Department;
            try
            {
                dept.Subordinate = dept.Subordinate.Split(',')[0].Trim(',');
                dept.DeptCode = model.ConfirmDeptCode;
                context.Departments.Add(dept);
                context.SaveChanges();
                logger.LogWarning("添加部门{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(dept));
            }
            catch (Exception ex)
            {
                logger.LogWarning("添加部门失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(dept));
                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var dept = context.Departments.Find(id);
                if (dept != null)
                {
                    context.Departments.Remove(dept);
                    context.SaveChanges();
                    logger.LogWarning("删除部门信息{LogType}{CustomProperty}", "Operate", "Id:" + id.ToString());
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("删除部门失败{LogType}{CustomProperty}", "Operate", "Id:" + id.ToString());
                throw ex;
            }
        }
        /// <summary>
        /// 修改部门，若失败返回false
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(DeptViewModel model)
        {
            bool result = false;
            var modelDept = model.Department;
            try
            {
                var dept = context.Departments.Find(modelDept.Id);
                if (modelDept.DeptCode != dept.DeptCode)
                {
                    var depts = context.Departments.FirstOrDefault(dept => dept.DeptCode == modelDept.DeptCode);
                    if (depts !=null)
                    {
                        return result;
                    }
                    dept.DeptCode = modelDept.DeptCode;
                }
                dept.Subordinate = modelDept.Subordinate.Split(',')[0].Trim(',');
                dept.DeptName = modelDept.DeptName;
                dept.Description = modelDept.Description;
                context.Departments.Update(dept);
                context.SaveChanges();
                logger.LogWarning("修改部门信息{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(modelDept));
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("修改部门信息失败{LogType}{CustomProperty}", "Operate", JsonConvert.SerializeObject(modelDept));
                throw ex;
            }
        }
        public Task<Department> FindByIdAsync(int deptId)=> Task.Run(() => context.Departments.Find(deptId));
        public int GetDeptId(string deptCode) 
        {
            Department department = context.Departments.FirstOrDefault(dept => dept.DeptCode == deptCode);
            int id= department.Id;
            return id;
        }
        public Task<List<string>> GetRolesIdAsync( int deptId)
        {
            return Task.Run(() => {
                var ids = new List<string>();
                ids= context.DeptRoles.ToList().Where(dr => dr.DeptId == deptId).Select(dr => dr.RoleId).ToList();
                return ids;
            } );
        }
        public Task<List<string>> GetRolesNameAsync(int deptId)
        {
            return Task.Run(() => {
                 var deptRoles=  context.DeptRoles.Where(dr=>dr.DeptId==deptId).ToList();
                List<string> names = new List<string>();
                foreach (var deptRole in deptRoles)
                {
                    var role = context.Roles.Find(deptRole.RoleId);
                    names.Add(role.Name);
                }
                return names;
            });
        }
        public Task<bool> IsInRoleAsync( int deptId,string roleId)
        {
            return Task.Run(()=> {
                var deptIds = context.DeptRoles.Where(dr => dr.RoleId == roleId).Select(dr => dr.DeptId);
                if (deptIds.Contains(deptId))
                {
                    return true;
                }
                else
                {
                   return false;
                }
            });
        }
        public Task<DeptResult> AddToRoleAsync(int deptId, string roleId)
        {
            return Task.Run(() => {
                try
                {
                    context.DeptRoles.Add(new DeptRole { DeptId = deptId, RoleId = roleId });
                    context.SaveChanges();
                    return new DeptResult { Succeeded = true };
                }
                catch(Exception ex)
                {
                    return new DeptResult { Succeeded = false, Error=ex.Message};
                }
            });
        }
        public Task<DeptResult> RemoveFromRoleAsync(int deptId, string roleId)
        {
            return Task.Run(() => {
                try
                {
                    var deptRoles = context.DeptRoles.Where(dr => dr.DeptId == deptId && dr.RoleId == roleId).ToList();
                    if (deptRoles.Count==1)
                    {
                        context.DeptRoles.Remove(deptRoles[0]);
                    }
                    else
                    {
                        context.DeptRoles.RemoveRange(deptRoles);
                    }
                    context.SaveChanges();
                    return new DeptResult { Succeeded = true };
                }
                catch
                {
                    return new DeptResult { Succeeded = false, Error = "发生了位置错误" };
                }
            });
        }

        public Task<Department> FindByDeptCodeAsync(string deptCode)=>Task.Run(()=>context.Departments.FirstOrDefault(dept => dept.DeptCode == deptCode));
    }
}
