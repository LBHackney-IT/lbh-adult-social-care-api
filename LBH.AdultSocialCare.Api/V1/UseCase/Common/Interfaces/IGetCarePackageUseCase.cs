using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetCarePackageUseCase
    {
        Task<IEnumerable<CarePackageListItemResponse>> GetAllAsync();

        Task<CarePackageResponse> GetSingleAsync(Guid packageId);

        Task<CarePackageCoreResponse> GetCarePackageCoreAsync(Guid carePackageId);

        Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters);
    }
}
