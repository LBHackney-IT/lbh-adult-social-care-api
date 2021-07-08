using System;

namespace Common.Exceptions.CustomExceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }
    }
}
