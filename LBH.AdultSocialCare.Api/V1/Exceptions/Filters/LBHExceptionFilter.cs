using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.V1.Exceptions.Filters
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Method)] // Only use attribute on controller classes and action methods
    public class LBHExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public LBHExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            Debugger.Break();

            int statusCode;

            ApiError apiError = null;
            switch (context.Exception)
            {
                case ApiException apiException:
                    // handle explicit 'known' API errors
                    context.Exception = null;
                    apiError = new ApiError(apiException.Message) { Errors = apiException.Errors, Detail = apiException.Detail };
                    statusCode = apiException.StatusCode;
                    break;

                case InvalidModelStateException invalidModelStateException:
                    apiError = new ApiError(invalidModelStateException.Errors, invalidModelStateException.Message);
                    statusCode = invalidModelStateException.StatusCode;
                    break;

                case DbSaveFailedException dbSaveFailedException:
                    apiError = new ApiError(dbSaveFailedException.Message);
                    statusCode = dbSaveFailedException.StatusCode;
                    break;

                case EntityNotFoundException entityNotFoundException:
                    apiError = new ApiError(entityNotFoundException.Message);
                    statusCode = entityNotFoundException.StatusCode;
                    break;

                case EntityConflictException entityConflictException:
                    apiError = new ApiError(entityConflictException.Message);
                    statusCode = entityConflictException.StatusCode;
                    break;

                case UnauthorizedAccessException _:
                    apiError = new ApiError("Unauthorized Access");
                    statusCode = 401;
                    break;

                default:
                    {
                        // Unhandled errors
#if !DEBUG
                        var msg = "An unhandled error occurred.";
                        string stack = null;
                        LambdaLogger.Log($"Application threw error: {JsonConvert.SerializeObject(context.Exception)}");
                        
#else
                        var msg = context.Exception.GetBaseException().Message;
                        string stack = context.Exception.StackTrace;
#endif

                        apiError = new ApiError(msg) { Detail = stack };
                        statusCode = 500;

                        // handle logging here
                        break;
                    }
            }

            context.HttpContext.Response.ContentType = "application/problem+json";
            context.HttpContext.Response.StatusCode = statusCode;
            // _logger.LogError($"Application threw error: {JsonConvert.SerializeObject(apiError)}");

            // always return a JSON result
            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}
