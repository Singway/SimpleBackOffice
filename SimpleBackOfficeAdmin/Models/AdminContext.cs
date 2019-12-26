using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBackOfficeAdmin.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Models
{
    public class AdminContext : IdentityDbContext<IdentityUserV2, IdentityRoleV2,string>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<BusinessPartner> Partners { get; set; }
        public DbSet<DeptRole>  DeptRoles { get; set; }
        public DbSet<DBLog> DBLogs { get; set; }
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("server=HONEYBEE\\SQLEXPRESS;database=BackOfficeDB;MultipleActiveResultSets=true;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }

}
