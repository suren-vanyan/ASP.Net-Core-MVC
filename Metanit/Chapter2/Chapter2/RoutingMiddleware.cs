using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter2
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/index")
            {
                await context.Response.WriteAsync("Home Page");
            }
            else if (path == "/about")
            {
                await context.Response.WriteAsync("About");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
            //await _next.Invoke(context);
        }
    }
}
