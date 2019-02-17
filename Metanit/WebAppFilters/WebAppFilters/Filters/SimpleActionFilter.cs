using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFilters.Filters
{
    public class SimpleActionFilter:Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // реализация отсутствует
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));
        }
    }
}
