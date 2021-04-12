using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Exceptions.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] // Only use attribute on controller classes and action methods
    public class LBHExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = context.Exception.Message;

            if (context.Exception is EntityNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            } else if (context.Exception is DbSaveFailedException)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = "Internal Server Error";
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int) statusCode;
            context.Result = new JsonResult(new
            {
                error = new[] { message }
                // stackTrace = context.Exception.StackTrace
            });
        }
    }
}
