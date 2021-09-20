using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum ClaimCollector
    {
        [Display(Name = "Supplier")]
        Supplier = 1,

        [Display(Name = "Hackney")]
        Hackney = 2
    }
}
