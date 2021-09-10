namespace LBH.AdultSocialCare.Api.V1.AppConstants
{
    public static class ApprovalHistoryConstants
    {
        public const string NewPackage = "Package Requested by";
        public const int NewPackageId = 1;
        public const string SubmittedForApproval = "Package Submitted for approval";
        public const int SubmittedForApprovalId = 2;
        public const string RequestMoreInformation = "Further information requested by";
        public const int RequestMoreInformationId = 3;
        public const string PackageApproved = "Care package Approved by";
        public const int PackageApprovedId = 4;
        public const string PackageBrokered = "Care Package Brokered by";
        public const int PackageBrokeredId = 5;
        public const string ApprovedForCommercial = "Care Package Approved for Commercial by";
        public const int ApprovedForCommercialId = 6;
        public const string ClarifyingCommercials = "Clarifying Commercials requested by";
        public const int ClarifyingCommercialsId = 7;
        public const string ApprovedForBrokerage = "Care Package Approved for Brokerage by";
        public const int ApprovedForBrokerageId = 8;
        public const string PackagePoIssued = "PO Issued by";
        public const int PackagePoIssuedId = 9;
        public const string BrokeredDealRejected = "Care Package rejected by";
        public const int BrokeredDealRejectedId = 10;
        public const string BrokeredEnded = "Package Ended";
        public const int BrokeredEndedId = 11;

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

                case PackageBrokeredId:
                    logText = PackageBrokered;
                    break;

                case ApprovedForCommercialId:
                    logText = ApprovedForCommercial;
                    break;

                case ClarifyingCommercialsId:
                    logText = ClarifyingCommercials;
                    break;

                case ApprovedForBrokerageId:
                    logText = ApprovedForBrokerage;
                    break;

                case PackagePoIssuedId:
                    logText = PackagePoIssued;
                    break;

                case BrokeredDealRejectedId:
                    logText = BrokeredDealRejected;
                    break;

                case BrokeredEndedId:
                    logText = BrokeredEnded;
                    break;
            }

            return logText;
        }
    }
}
