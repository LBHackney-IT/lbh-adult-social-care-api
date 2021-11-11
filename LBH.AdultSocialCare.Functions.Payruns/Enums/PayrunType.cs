using System.ComponentModel;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
{
    public enum PayrunType
    {
        [Description("Residential Recurring")]
        ResidentialRecurring = 1,

        [Description("Direct Payments")]
        DirectPayments = 2,

        [Description("Home Care")]
        HomeCare = 3
    }
}
