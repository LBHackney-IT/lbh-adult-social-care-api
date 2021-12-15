using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum PayRunHistoryType
    {
        [Display(Name = "NormalRecord")]
        NormalRecord = 1,

        [Display(Name = "CedarFileDownload")]
        CedarFileDownload = 2,

        [Display(Name = "PaidPayrun")]
        PaidPayrun = 3
    }
}
