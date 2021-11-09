using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public static class FilterPreferences
    {
        public static List<string> PackageItemStatus()
        {
            return new List<String>
            {
                PackageStatus.InProgress.GetDisplayName(),
                ReclaimStatus.Active.GetDisplayName(),
                ReclaimStatus.Pending.GetDisplayName(),
                ReclaimStatus.Cancelled.GetDisplayName(),
                ReclaimStatus.Ended.GetDisplayName()
            };
        }
    }
}
