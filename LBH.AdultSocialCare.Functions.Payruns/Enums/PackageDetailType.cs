using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
{
    public enum PackageDetailType
    {
        [Display(Name = "Core Cost")]
        CoreCost = 1,

        [Display(Name = "Additional Need")]
        AdditionalNeed = 2
    }
}
