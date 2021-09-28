using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IUpdateCarePackageUseCase
    {
        public Task<CarePackagePlainResponse> UpdateAsync(Guid carePackageId, CarePackageUpdateDomain carePackageUpdateDomain);
    }
}
