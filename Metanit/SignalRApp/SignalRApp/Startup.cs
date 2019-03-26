﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chat",options=>
                {
                    options.ApplicationMaxBufferSize = 64;
                    options.TransportMaxBufferSize = 64;
                    options.LongPolling.PollTimeout = System.TimeSpan.FromMinutes(1);
                    options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
                });
            });

           
        }
    }
}
