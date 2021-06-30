using System.ComponentModel;

namespace Common.AppConstants.Enums
{
    public enum PayRunTypeEnum : int
    {
        [Description("Residential Recurring")]
        ResidentialRecurring = 1,

        [Description("Direct Payments")]
        DirectPayments = 2,

        [Description("Home Care")]
        HomeCare = 3
    }
}
