using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum PackageDetailType
    {
        [Display(Name = "Core Cost")]
        CoreCost = 1,

        [Display(Name = "Additional Need")]
        AdditionalNeed = 2
    }
}
