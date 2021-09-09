using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum CareChargeElementTypeEnum
    {
        [Display(Name = "Provisional")]
        Provisional = 1,

        [Display(Name = "Without Property 1-12 Weeks")]
        WithoutPropertyOneToTwelveWeeks = 2,

        [Display(Name = "Without Property 13+ Weeks")]
        WithoutPropertyThirteenPlusWeeks = 3
    }
}
