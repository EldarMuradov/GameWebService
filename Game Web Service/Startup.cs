using Game_Web_Service.Models;
using Game_Web_Service.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Web_Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            services.AddScoped<IUsersCollection, UsersCollection>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "home",
                        pattern: "{controller=HomeController}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                        name: "account",
                        pattern: "{controller=AccountController}/{action=Details}/{id?}");
                endpoints.MapControllerRoute(
                        name: "account",
                        pattern: "{controller=AccountController}/{action=Index}/{id?}");
            });

            app.Run(async context => 
            {
                await context.Response.WriteAsync("Hello World");
            });
            

        }
    }
}
