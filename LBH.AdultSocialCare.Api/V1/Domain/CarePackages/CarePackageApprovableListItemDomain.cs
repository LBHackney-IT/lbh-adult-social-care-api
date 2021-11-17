using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System;
using Common.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateListMappingFor(typeof(CarePackage))]
    [GenerateListMappingFor(typeof(CarePackageApprovableListItemResponse))]
    public class CarePackageApprovableListItemDomain
    {
        public ServiceUserDomain ServiceUser { get; set; }
        public UsersMinimalDomain Approver { get; set; }

        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public PackageStatus Status { get; set; }

        public DateTimeOffset? DateAssigned { get; set; }
    }
}
