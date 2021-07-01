using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpdateResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate);
    }
}
