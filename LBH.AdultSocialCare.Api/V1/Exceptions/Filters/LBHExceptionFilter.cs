using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Net;
using Common.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Exceptions.Filters
{

    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Method)] // Only use attribute on controller classes and action methods
    public class LBHExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            Debugger.Break();

            var statusCode = HttpStatusCode.InternalServerError;
            var message = context.Exception.Message;

            switch (context.Exception)
            {
                case EntityNotFoundException _:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case DbSaveFailedException _:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
                case EntityConflictException _:
                    statusCode = HttpStatusCode.Conflict;
                    break;
                default:
                    message = "Internal Server Error";
                    break;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int) statusCode;

            context.Result = new JsonResult(new
            {
                error = new[]
                {
                    message
                }

                // stackTrace = context.Exception.StackTrace
            });
        }

    }

}
