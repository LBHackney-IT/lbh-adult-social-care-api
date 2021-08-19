using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces
{
    public interface IGetResidentialCareApprovePackageUseCase
    {
        public Task<ResidentialCareApprovePackageResponse> Execute(Guid residentialCarePackageId);
    }
}
