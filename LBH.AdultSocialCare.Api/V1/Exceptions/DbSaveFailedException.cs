namespace LBH.AdultSocialCare.Api.V1.Exceptions
{
    public class DbSaveFailedException : CustomException
    {
        public DbSaveFailedException() : base("Save to db was not successful")
        {
        }

        public DbSaveFailedException(string message) : base(message)
        {
        }
    }
}
