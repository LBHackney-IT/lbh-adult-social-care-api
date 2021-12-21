using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum RolesEnum
    {
        [Description("7335e791-1d08-437a-974e-809944d29bc6")]
        [Display(Name = "Super User")]
        SuperUser = 1,

        [Description("97c46919-fd10-47f1-bcb9-fa6b513c4c83")]
        [Display(Name = "Brokerage")]
        Broker = 2,

        [Description("d7cb6746-1211-4cc2-9244-f4faaef25089")]
        [Display(Name = "Brokerage Approver")]
        BrokerageApprover = 3,

        [Description("74b93ac7-1778-485d-a482-d76893f31aff")]
        [Display(Name = "Finance")]
        Finance = 4,

        [Description("80f1ea68-9335-4efe-b247-7aa58cc45af0")]
        [Display(Name = "Finance Approver")]
        FinanceApprover = 5,

        [Description("7b955348-e506-4c93-abc4-64d27d559f41")]
        [Display(Name = "Care Charge Manager")]
        CareChargeManager = 6
    }
}
