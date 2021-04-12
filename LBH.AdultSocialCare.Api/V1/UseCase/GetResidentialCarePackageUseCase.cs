using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class GetResidentialCarePackageUseCase : IGetResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        public GetResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<ResidentialCarePackageDomain> GetAsync(Guid residentialCarePackageId)
        {
            var packageEntity = await _gateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);
            return ResidentialCarePackageFactory.ToDomain(packageEntity);
        }
    }
}
