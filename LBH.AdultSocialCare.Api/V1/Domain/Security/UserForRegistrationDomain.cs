namespace LBH.AdultSocialCare.Api.V1.Domain.Security
{
    public class UserForRegistrationDomain
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        // public ICollection<string> Roles { get; set; }
    }
}
