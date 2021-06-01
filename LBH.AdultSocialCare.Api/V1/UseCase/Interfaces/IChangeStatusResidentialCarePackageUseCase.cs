using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IChangeStatusResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId);
    }
}
