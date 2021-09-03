using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IBrokeredPackagesGateway
    {
        Task<PagedList<BrokeredPackagesDomain>> GetBrokeredPackages(BrokeredPackagesParameters parameters, int statusId);

        Task<bool> AssignToUser(Guid packageId, Guid userId);
    }
}
