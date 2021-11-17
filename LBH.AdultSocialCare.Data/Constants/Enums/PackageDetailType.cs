using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PackageDetailType
    {
        [Display(Name = "Core Cost")]
        CoreCost = 1,

        [Display(Name = "Additional Need")]
        AdditionalNeed = 2
    }
}
