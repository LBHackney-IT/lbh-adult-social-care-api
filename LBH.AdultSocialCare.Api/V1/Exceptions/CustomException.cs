using System;

namespace LBH.AdultSocialCare.Api.V1.Exceptions
{
    public abstract class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }
    }
}
