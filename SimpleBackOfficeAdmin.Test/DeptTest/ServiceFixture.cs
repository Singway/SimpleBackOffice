using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBackOfficeAdmin.Test
{
    public  class ServiceFixture:IDisposable
    {
        public DeptManager Sut { get; }
        public UserService UserService { get; set; }
        public ServiceFixture()
        {
            var admin = new AdminContext(new DbContextOptions < AdminContext >() );
             ILogger<DeptManager> logger=new LoggerTest();
            Sut = new DeptManager(admin, logger);
        }

        public void Dispose()
        {
           
        }
    }
}
