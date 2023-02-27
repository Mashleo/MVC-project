using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC_Diplom_project.Data;
//using Microsoft.Extensions.Hosting;
using MVC_Diplom_project.Data.Interfaces;
using MVC_Diplom_project.Data.Mocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Diplom_project.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MVC_Diplom_project
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("dbsetting.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarPortalDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddOpenApiDocument();
            services.AddDataProtection();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => 
                {
                   options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               });
            services.AddControllersWithViews();
            
            services.AddTransient<ICars, CarRepository>();
            services.AddTransient<ILogbook, LogbooksRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOpenApi(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            app.UseReDoc(); // serve ReDoc UI

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseDeveloperExceptionPage(); 
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
