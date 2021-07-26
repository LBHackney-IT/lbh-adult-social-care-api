using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.AppConstants
{
    public static class PackageStageConstants
    {
        public const string BrokerageAssigned = "Brokerage - Assigned to";
        public const int BrokerageAssignedId = 2;
        public const string BrokerageQuerying = "Brokerage - Queried by";
        public const int BrokerageQueryingId = 3;
        public const string BrokerageSupplierSourced = "Brokerage - Supplier sourced by";
        public const int BrokerageSupplierSourcedId = 4;
        public const string BrokeragePricingAgreed = "Brokerage - Pricing Agreed by";
        public const int BrokeragePricingAgreedId = 5;

        public static string GetStageText(int stageId)
        {
            var stageText = "";
            switch (stageId)
            {
                case BrokerageAssignedId:
                    stageText = BrokerageAssigned;
                    break;
                case BrokerageQueryingId:
                    stageText = BrokerageQuerying;
                    break;
                case BrokerageSupplierSourcedId:
                    stageText = BrokerageSupplierSourced;
                    break;
                case BrokeragePricingAgreedId:
                    stageText = BrokeragePricingAgreed;
                    break;
            }

            return stageText;
        }
    }
}
