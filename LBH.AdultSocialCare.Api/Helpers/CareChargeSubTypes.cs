using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public static class CareChargeSubTypes
    {
        public static ReclaimSubType GetCareChargeSubTypeOrder(ReclaimSubType subType)
        {
            return subType switch
            {
                ReclaimSubType.CareChargeProvisional => ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks => ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                _ => ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
            };
        }
    }
}
