using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class ServiceUserPackageViewItemResponse
    {
        public Guid PackageId { get; set; }
        public string PackageStatus { get; set; }
        public string PackageType { get; set; }
        public bool? IsS117Client { get; set; }
        public bool? IsS117ClientConfirmed { get; set; }
        public DateTimeOffset? DateAssigned { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
        public Guid? SocialWorkerCarePlanFileId { get; set; }
        public string SocialWorkerCarePlanFileName { get; set; }
        public IEnumerable<CarePackageHistoryResponse> Notes { get; set; }
        public IEnumerable<CarePackageCostItemResponse> PackageItems { get; set; }
    }
}
