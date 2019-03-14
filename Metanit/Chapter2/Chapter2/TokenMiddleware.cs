using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter2
{
    public class TokenMiddleware
    {
        RequestDelegate requestDelegate;
        public TokenMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Query["token"] != "123456")
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Token is invalid");
            }
           await requestDelegate.Invoke(httpContext);
        }
    }
}
