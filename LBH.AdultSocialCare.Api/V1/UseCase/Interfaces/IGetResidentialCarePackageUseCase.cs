using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> GetAsync(Guid residentialCarePackageId);
    }
}
