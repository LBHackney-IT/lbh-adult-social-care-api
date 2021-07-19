using System.Net;

namespace Common.Exceptions.CustomExceptions
{
    public class EntityConflictException : CustomException
    {
        public int StatusCode { get; set; } = (int) HttpStatusCode.Conflict;

        public EntityConflictException() : base("Entity conflict")
        {
        }

        public EntityConflictException(string message) : base(message)
        {
        }
    }
}
