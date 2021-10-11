using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum PackageDetailType
    {
        [Display(Name = "Core Cost")]
        CoreCost = 1,

        [Display(Name = "Additional Need")]
        AdditionalNeed = 2
    }
}
