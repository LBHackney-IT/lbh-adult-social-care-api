using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface IBrokeredPackagesGateway
    {
        Task<PagedList<BrokeredPackagesDomain>> GetBrokeredPackages(BrokeredPackagesParameters parameters, int statusId);

        Task<bool> AssignToUser(Guid packageId, Guid userId);
    }
}
