using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.Services;
using SimpleBackOfficeAdmin.ViewModels;
using System;
using System.Collections.Generic;
using Xunit;

namespace SimpleBackOfficeAdmin.Test
{
    public class TestDeptManager:IClassFixture<ServiceFixture>,IDisposable
    {
        private readonly DeptManager deptManager;

        public TestDeptManager(ServiceFixture fixture)
        {
            deptManager = fixture.Sut;
        }

        public void Dispose()
        {
            
        }

        [Fact]
        public void IndexShouldBe_OK()
        {
            List<Department> departments = deptManager.Index().Departments;
            Assert.True(departments .Count> 0);
            Assert.Contains(departments, d => d.DeptName == "财务部");
        }

        [Fact]
        public void EditShouldBe_OK()
        {
            var model = new DeptViewModel();
            model.Department.Id = 20;
            model.Department.DeptCode = "112";
            model.Department.DeptName = "测试部";
            model.Department.Subordinate = "404,技术部";
            model.Department.Description = "测试部门";
            bool result = deptManager.Edit(model);
            Assert.True(result);
        }
    }
}
