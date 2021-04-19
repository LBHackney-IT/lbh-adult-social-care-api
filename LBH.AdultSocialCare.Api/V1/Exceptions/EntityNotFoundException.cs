namespace LBH.AdultSocialCare.Api.V1.Exceptions
{
    public class EntityNotFoundException : CustomException
    {
        public EntityNotFoundException() : base("Entity was not found")
        {

        }
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
