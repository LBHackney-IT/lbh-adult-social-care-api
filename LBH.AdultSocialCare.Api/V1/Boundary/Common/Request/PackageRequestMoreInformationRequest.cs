using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class PackageRequestMoreInformationRequest
    {
        [Required] public string InformationText { get; set; }
    }
}
