using System;

namespace Common.Exceptions.CustomExceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }

        protected CustomException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
