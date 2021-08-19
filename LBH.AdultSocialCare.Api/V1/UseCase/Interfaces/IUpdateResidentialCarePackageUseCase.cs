using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpdateResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate);
    }
}
