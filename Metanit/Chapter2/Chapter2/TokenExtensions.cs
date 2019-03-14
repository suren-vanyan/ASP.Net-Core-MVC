using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter2
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenMiddleware>();
        }
    }
}
