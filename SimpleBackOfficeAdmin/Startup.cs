using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using SimpleBackOfficeAdmin.CustomMidware;
using SimpleBackOfficeAdmin.Models;
using SimpleBackOfficeAdmin.Services;

namespace SimpleBackOfficeAdmin
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(configure=>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddScoped<IDeptManager, DeptManager>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddDbContextPool<AdminContext>(opt=>opt.UseSqlServer(configuration.GetConnectionString("linkWord")));

            services.AddIdentity<IdentityUserV2, IdentityRoleV2>()
                .AddErrorDescriber<IdentityErrorDescription_CN>()
                .AddEntityFrameworkStores<AdminContext>();

            services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredUniqueChars = 4;
                option.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(options => {
                options.AccessDeniedPath = "/Account/Deny";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //将日志记录到数据库                 config/NLog.config
            LogManager.LoadConfiguration("Nlog.config").GetCurrentClassLogger();
            //避免日志中的中文输出乱码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //错误页面
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
