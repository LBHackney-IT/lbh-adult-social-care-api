using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PayRunHistoryType
    {
        [Display(Name = "NormalRecord")]
        NormalRecord = 1,

        [Display(Name = "CedarFileDownload")]
        CedarFileDownload = 2
    }
}
