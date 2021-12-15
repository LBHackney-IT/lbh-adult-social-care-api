using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum ReclaimSubType
    {
        [Display(Name = "Provisional Care Charge")]
        CareChargeProvisional = 1,

        [Display(Name = "Without Property 1-12 Weeks")]
        CareChargeWithoutPropertyOneToTwelveWeeks = 2,

        [Display(Name = "Without Property 13+ Weeks")]
        CareChargeWithoutPropertyThirteenPlusWeeks = 3
    }
}
