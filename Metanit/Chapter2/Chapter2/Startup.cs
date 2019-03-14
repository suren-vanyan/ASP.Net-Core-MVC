using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Chapter2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseToken();
            app.Map("/Index", Index);
            app.MapWhen(context => 2 < 3, Index);
            int x = 2;
            app.Use(async (context, next) =>
            {
                x *= 2;

                await next.Invoke();
                x *= 2;
                await context.Response.WriteAsync($"Result: {x}");
            });
            app.Run(async (context) =>
            {
                x *= 2;
                await Task.FromResult(0);
            });


        }
        public void Index(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Prior");
            });
        }

    }
}
