using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate requestDelegate;
        public ShortCircuitMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        } 

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("edge")))
            {
                 httpContext.Response.StatusCode = 403;
            }
            else
            {
                await requestDelegate.Invoke(httpContext);
            }
        }
    }
}
