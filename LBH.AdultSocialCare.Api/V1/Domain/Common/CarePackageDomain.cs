using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageResponse))]
    [GenerateListMappingFor(typeof(CarePackageResponse))]
    public class CarePackageDomain
    {
        public Guid CarePackageId { get; set; }
        public string PackageStatus { get; set; }
        public string ClientName { get; set; }
        public DateTimeOffset ClientDateOfBirth { get; set; }
        public string HackneyId { get; set; }
        public string PostCode { get; set; }
        public string AssignedBrokerName { get; set; }
        public string DateCreated { get; set; }
    }
}
