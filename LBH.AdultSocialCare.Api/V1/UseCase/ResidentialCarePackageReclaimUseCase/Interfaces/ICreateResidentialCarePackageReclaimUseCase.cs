using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageReclaimDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCarePackageReclaimUseCase.Interfaces
{
    public interface ICreateResidentialCarePackageReclaimUseCase
    {
        Task<ResidentialCarePackageClaimResponse> ExecuteAsync(ResidentialCarePackageClaimCreationDomain residentialCarePackageClaimCreationDomain);
    }
}
