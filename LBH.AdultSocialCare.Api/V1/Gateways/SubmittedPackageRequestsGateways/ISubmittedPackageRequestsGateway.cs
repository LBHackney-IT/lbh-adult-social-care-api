using LBH.AdultSocialCare.Api.V1.Domain.PackageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SubmittedPackageRequestsGateways
{
    public interface ISubmittedPackageRequestsGateway
    {
        Task<PagedList<SubmittedPackageRequestsDomain>> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters);

        Task<IEnumerable<StatusDomain>> GetSubmittedPackageRequestsStatus();
    }
}
