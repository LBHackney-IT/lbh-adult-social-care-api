using System.ComponentModel;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PayrunType
    {
        [Description("Residential Recurring")]
        ResidentialRecurring = 1,

        [Description("Direct Payments")]
        DirectPayments = 2,

        [Description("Residential Released Holds")]
        ResidentialReleasedHolds = 3,

        [Description("Direct Payments Released Holds")]
        DirectPaymentsReleasedHolds = 4,
    }
}
