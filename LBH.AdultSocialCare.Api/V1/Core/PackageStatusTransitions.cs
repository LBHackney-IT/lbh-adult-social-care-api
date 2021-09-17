using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Extensions;

namespace LBH.AdultSocialCare.Api.V1.Core
{
    public static class PackageStatusTransitions
    {
        /// <summary>
        /// Returns true if transition from the currentStatusId to a newStatusId is possible, otherwise, false.
        /// </summary>
        public static bool CanChangeStatus(int currentStatusId, int newStatusId)
        {
            switch (newStatusId)
            {
                case ApprovalHistoryConstants.PackageApprovedId:
                    return currentStatusId.NotIn(
                        ApprovalHistoryConstants.PackageApprovedId,
                        ApprovalHistoryConstants.PackageBrokeredId);

                default:
                    return true;
            }
        }
    }
}
