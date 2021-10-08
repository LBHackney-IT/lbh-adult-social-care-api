using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetCareChargePackagesUseCase
    {
        Task<PagedResponse<CareChargePackagesResponse>> GetCareChargePackages(CareChargePackagesParameters parameters);
    }
}
