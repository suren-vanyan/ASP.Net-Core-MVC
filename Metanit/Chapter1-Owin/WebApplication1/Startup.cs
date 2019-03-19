using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            app.Run(async (context) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);
                await context.Response.WriteAsync("Hello World!");
            });
        }




        public Task SendResponseAsync(IDictionary<string,object> enviroment)
        {
            string responseText = "Hello Asp.net Core";
            var byteResponse = Encoding.UTF8.GetBytes(responseText);

            var responseStream = enviroment["owin.ResponseBody"] as Stream;
            return responseStream.WriteAsync(byteResponse, 0, byteResponse.Length);
        }

        public Task SendNewResponseAsync(IDictionary<string, object> enviroment)
        {
            var requestHeaders = enviroment["owin.RequestHeaders"] as IDictionary<string, string[]>;
            string responseText = requestHeaders["User-Agent"][0];
          
            var responseByte = Encoding.UTF8.GetBytes(responseText);

            var responseStream = enviroment["owin.ResponseBody"] as Stream;
            return responseStream.WriteAsync(responseByte, 0, responseByte.Length);
        }
    }
}
