using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.AppConstants
{
    public static class ApprovalHistoryConstants
    {
        public const string NewPackage = "Package Requested by ";
        public const int NewPackageId = 1;
        public const string SubmittedForApproval = "Package Submitted for approval ";
        public const int SubmittedForApprovalId = 2;
        public const string RequestMoreInformation = "Further information requested by ";
        public const int RequestMoreInformationId = 3;
        public const string PackageApproved = "Care package Approved by ";
        public const int PackageApprovedId = 4;
        public const string ApprovedForBrokerage = "Care Package Approved for Brokerage by ";
        public const int ApprovedForBrokerageId = 6;
        public const string PackageBrokered = "Care Package Brokered by ";
        public const int PackageBrokeredId = 8;
        public const string BrokeredDealRejected = "Care Package rejected by ";
        public const int BrokeredDealRejectedId = 10;

        public static string GetLogText(int statusId)
        {
            var logText = "";
            switch (statusId)
            {
                case NewPackageId:
                    logText = NewPackage;
                    break;
                case SubmittedForApprovalId:
                    logText = SubmittedForApproval;
                    break;
                case RequestMoreInformationId:
                    logText = RequestMoreInformation;
                    break;
                case PackageApprovedId:
                    logText = PackageApproved;
                    break;
                case ApprovedForBrokerageId:
                    logText = ApprovedForBrokerage;
                    break;
                case PackageBrokeredId:
                    logText = PackageBrokered;
                    break;
                case BrokeredDealRejectedId:
                    logText = BrokeredDealRejected;
                    break;
            }

            return logText;
        }
    }
}
