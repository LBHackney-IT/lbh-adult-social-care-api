namespace LBH.AdultSocialCare.Api.V1.Exceptions
{
    public class EntityConflictException : CustomException
    {
        public EntityConflictException() : base("Entity conflict")
        {
        }

        public EntityConflictException(string message) : base(message)
        {
        }
    }
}
