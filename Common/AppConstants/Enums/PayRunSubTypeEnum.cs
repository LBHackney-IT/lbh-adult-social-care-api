using System.ComponentModel;

namespace Common.AppConstants.Enums
{
    public enum PayRunSubTypeEnum : int
    {
        [Description("Residential Release Holds")]
        ResidentialReleaseHolds = 1,

        [Description("Direct Payments Release Holds")]
        DirectPaymentsReleaseHolds = 2
    }
}
