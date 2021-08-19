using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.BrokeredPackagesGateways
{
    public interface IBrokeredPackagesGateway
    {
        Task<PagedList<BrokeredPackagesDomain>> GetBrokeredPackages(BrokeredPackagesParameters parameters, int statusId);

        Task<bool> AssignToUser(Guid packageId, Guid userId);
    }
}
