using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
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
