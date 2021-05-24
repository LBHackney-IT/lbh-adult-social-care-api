using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCarePackageReclaimUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCarePackageReclaimUseCase.Concrete
{
    public class CreateResidentialCarePackageReclaimUseCase : ICreateResidentialCarePackageReclaimUseCase
    {
        private readonly IResidentialCarePackageReclaimGateway _residentialCarePackageReclaimGateway;

        public CreateResidentialCarePackageReclaimUseCase(IResidentialCarePackageReclaimGateway residentialCarePackageReclaimGateway)
        {
            _residentialCarePackageReclaimGateway = residentialCarePackageReclaimGateway;
        }

        public async Task<ResidentialCarePackageClaimResponse> ExecuteAsync(ResidentialCarePackageClaimCreationDomain residentialCarePackageClaimCreationDomain)
        {
            var residentialCarePackageClaimEntity = residentialCarePackageClaimCreationDomain.ToDb();
            var res = await _residentialCarePackageReclaimGateway.CreateAsync(residentialCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
