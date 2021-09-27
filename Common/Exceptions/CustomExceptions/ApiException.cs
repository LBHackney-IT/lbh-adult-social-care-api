using Common.Exceptions.Models;
using System;
using System.Net;

namespace Common.Exceptions.CustomExceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public ValidationErrorCollection Errors { get; set; }

        public string Detail { get; set; }

        public ApiException(string message,
            int statusCode = 500,
            ValidationErrorCollection errors = null,
            string detail = null) :
            base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
            Detail = detail;
        }

        public ApiException(string message, HttpStatusCode statusCode)
            : this(message, (int) statusCode)
        {
        }
    }
}
