using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public static class CareChargeSubTypes
    {
        public static ReclaimSubType GetCareChargeSubTypeOrder(ReclaimSubType? subType)
        {
            return subType switch
            {
                ReclaimSubType.CareChargeProvisional => ReclaimSubType.CareCharge1To12Weeks,
                ReclaimSubType.CareCharge1To12Weeks => ReclaimSubType.CareCharge13PlusWeeks,
                _ => ReclaimSubType.CareCharge13PlusWeeks
            };
        }
    }
}
