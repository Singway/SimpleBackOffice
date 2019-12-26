using Microsoft.EntityFrameworkCore;
using SimpleBackOfficeAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Migrations
{
    public static class DepartmentSeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Department>()
                .HasData(new Department[]
                {
                    new Department
                    {
                        Id=1,
                        DeptCode = "100",
                        DeptName = "Back-Office Admin",
                        Subordinate = "0",
                        Description="后台操作管理人员分组，拥有几乎所有权限"
                    },
                    new Department
                    {
                        Id=2,
                        DeptCode = "101",
                        DeptName = "总部",
                        Subordinate = "0",
                        Description="总部"
                    }
                });
        }
    }
}
