using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlsAndRoutes.Infrastructure
{
    public class WeekDayConstraint : IRouteConstraint
    {
        private static string[] Days = new[] { "mon", "tue", "wed", "thu","fri", "sat", "sun" };
        bool IRouteConstraint.Match(HttpContext httpContext, IRouter route, 
            string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return Days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }

}


