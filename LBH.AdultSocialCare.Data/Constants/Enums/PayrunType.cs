using System.ComponentModel;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
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
