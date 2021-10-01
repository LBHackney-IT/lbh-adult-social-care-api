using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetCarePackageUseCase
    {
        Task<IEnumerable<CarePackageResponse>> GetAllAsync();

        Task<CarePackageSettingsResponse> GetCarePackageSettingsAsync(Guid carePackageId);
    }
}
