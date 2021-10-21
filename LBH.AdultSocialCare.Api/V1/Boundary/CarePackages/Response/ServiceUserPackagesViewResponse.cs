using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class ServiceUserPackagesViewResponse
    {
        public ServiceUserBasicResponse ServiceUser { get; set; }
        public IEnumerable<ServiceUserPackageViewItemResponse> Packages { get; set; }
    }
}
