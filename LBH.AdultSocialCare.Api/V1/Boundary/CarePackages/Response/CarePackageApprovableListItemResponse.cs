using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageApprovableListItemResponse
    {
        public ServiceUserResponse ServiceUser { get; set; }
        public UsersMinimalResponse Approver { get; set; }

        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public PackageStatus Status { get; set; }

        public DateTimeOffset? DateAssigned { get; set; }
    }
}
