using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageUseCase
    {
        Task<IEnumerable<CarePackageListItemResponse>> GetAllAsync();

        Task<CarePackageResponse> GetSingleAsync(Guid packageId);

        Task<CarePackageResponse> GetCarePackageCoreAsync(Guid carePackageId);

        Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters);
    }
}
