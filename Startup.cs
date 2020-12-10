using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGo
{
    //https://github.com/etrupja/DrinkAndGo - source code
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDrinkRepository, MockDrinkRepository>();
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            services.AddMvc();
            // important!!!
            services.AddMvc(option => option.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //LoggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //if (env.IsDevelopment())
            //{
            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("IsDevelopment");
            //    });
            //}

            //if (env.IsProduction())
            //{
            //    app.Run(async (context) =>
            //    {
            //    await context.Response.WriteAsync("IsProduction");
            //    });
            //}
        }
    }
}
