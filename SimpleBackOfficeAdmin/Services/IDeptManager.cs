using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Services
{
    public interface IDeptManager
    {
        IEnumerable<Department> Departments { get; set; }
        public DeptViewModel Index(Department errorModel = null);
        public void Create(DeptViewModel model);
        public void Delete(int id);
        public bool Edit(DeptViewModel model);
        public Task<Department> FindByIdAsync(int deptId);
        public Task<Department> FindByDeptCodeAsync(string deptCode);
        int GetDeptId(string deptCode);
        Task<List<string>> GetRolesIdAsync(int deptId);
        Task<List<string>> GetRolesNameAsync( int deptId);
        Task<bool> IsInRoleAsync(int deptId, string roleId);
        Task<DeptResult> AddToRoleAsync( int deptId, string roleId);
        Task<DeptResult> RemoveFromRoleAsync(int deptId, string roleId);
    }
}
