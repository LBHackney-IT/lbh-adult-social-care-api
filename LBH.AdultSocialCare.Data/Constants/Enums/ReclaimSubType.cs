using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum ReclaimSubType
    {
        [Display(Name = "Provisional")]
        CareChargeProvisional = 1,

        [Display(Name = "Without Property 1-12 Weeks")]
        CareChargeWithoutPropertyOneToTwelveWeeks = 2,

        [Display(Name = "Without Property 13+ Weeks")]
        CareChargeWithoutPropertyThirteenPlusWeeks = 3
    }
}
