using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageDetailsUseCase
    {
        Task<IEnumerable<CarePackageDetailResponse>> GetCarePackageDetails(Guid carePackageId);
    }
}
