using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1
{

    public class CorrelationMiddleware
    {

        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers[CorrelationConstants.CorrelationId].Count == 0)
            {
                context.Request.Headers[CorrelationConstants.CorrelationId] = Guid.NewGuid().ToString();
            }

            if (_next != null)
                await _next(context).ConfigureAwait(false);
        }

    }

    public static class CorrelationMiddlewareExtensions
    {

        public static IApplicationBuilder UseCorrelation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationMiddleware>();
        }

    }

}
