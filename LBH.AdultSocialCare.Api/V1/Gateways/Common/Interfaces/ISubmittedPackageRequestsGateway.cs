using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ISubmittedPackageRequestsGateway
    {
        Task<PagedList<SubmittedPackageRequestsDomain>> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters);

        Task<IEnumerable<StatusDomain>> GetSubmittedPackageRequestsStatus();
    }
}