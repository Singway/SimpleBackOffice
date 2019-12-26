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
            Assert.Contains(departments, d => d.DeptName == "����");
        }

        [Fact]
        public void EditShouldBe_OK()
        {
            var model = new DeptViewModel();
            model.Department.Id = 20;
            model.Department.DeptCode = "112";
            model.Department.DeptName = "���Բ�";
            model.Department.Subordinate = "404,������";
            model.Department.Description = "���Բ���";
            bool result = deptManager.Edit(model);
            Assert.True(result);
        }
    }
}
