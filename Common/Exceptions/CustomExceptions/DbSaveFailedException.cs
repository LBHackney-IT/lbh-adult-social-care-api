using System;
using System.Net;

namespace Common.Exceptions.CustomExceptions
{
    public class DbSaveFailedException : CustomException
    {
        public int StatusCode { get; set; } = (int) HttpStatusCode.InternalServerError;

        public DbSaveFailedException() : base("Save to db was not successful")
        {
        }

        public DbSaveFailedException(string message) : base(message)
        {
        }

        public DbSaveFailedException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
