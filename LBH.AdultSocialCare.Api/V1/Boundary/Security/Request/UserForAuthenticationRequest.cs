using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Request
{
    public class UserForAuthenticationRequest
    {
        [Required(ErrorMessage = "User name is required")] public string UserName { get; set; }
        [Required(ErrorMessage = "Password name is required")] public string Password { get; set; }
    }
}
