using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetCarePackageUseCase
    {
        Task<IEnumerable<CarePackageResponse>> GetAllAsync();

        Task<CarePackageSettingsResponse> GetCarePackageSettingsAsync(Guid carePackageId);

        Task<BrokerPackageViewResponse> GetBrokerPackageViewListAsync(BrokerPackageViewQueryParameters queryParameters);
    }
}
