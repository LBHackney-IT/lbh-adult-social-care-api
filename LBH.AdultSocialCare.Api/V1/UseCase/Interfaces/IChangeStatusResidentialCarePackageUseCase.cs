using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IChangeStatusResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId);
    }
}
