using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate requestDelegate, UptimeService uptimeService)
        {
            nextDelegate = requestDelegate;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["ChromeBrowser"]
            = httpContext.Request.Headers["User-Agent"]
            .Any(v => v.ToLower().Contains("chrome"));
            await nextDelegate.Invoke(httpContext);
        }

       
    }
}
