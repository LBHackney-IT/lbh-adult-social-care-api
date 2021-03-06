using LBH.AdultSocialCare.Data.Attributes;
using System.ComponentModel;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum PayrunType
    {
        [Description("Residential Recurring")]
        ResidentialRecurring = 1,

        [Description("Residential Released Holds")]
        ResidentialReleasedHolds = 2
    }
}
