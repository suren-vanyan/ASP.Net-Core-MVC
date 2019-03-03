using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptimeService;
        public ContentMiddleware(RequestDelegate requestDelegate, UptimeService uptimeService)
        {
            nextDelegate = requestDelegate;
            this.uptimeService = uptimeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware"+
                    $"Uptime Service {uptimeService.UpTime} ms", Encoding.UTF8);
              
            }
            else
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
