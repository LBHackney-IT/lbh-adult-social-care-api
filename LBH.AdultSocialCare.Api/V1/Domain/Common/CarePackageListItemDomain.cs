using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageListItemResponse))]
    [GenerateListMappingFor(typeof(CarePackageListItemResponse))]
    public class CarePackageListItemDomain
    {
        public Guid CarePackageId { get; set; }
        public string PackageStatus { get; set; }
        public string ClientName { get; set; }
        public DateTimeOffset ClientDateOfBirth { get; set; }
        public int HackneyId { get; set; }
        public string PostCode { get; set; }
        public string AssignedBrokerName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
