using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum PackageResourceType
    {
        [Display(Name = "Care Plan File")]
        CarePlanFile = 1,

        [Display(Name = "FNC Assessment File")]
        FncAssessmentFile = 2,

        [Display(Name = "Care Charge Assessment File")]
        CareChargeAssessmentFile = 3
    }
}
