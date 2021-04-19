using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases
{
    public class GetAllResidentialCarePackageUseCase : IGetAllResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        public GetAllResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<IList<ResidentialCarePackageDomain>> GetAllAsync()
        {
            var result = await _gateway.ListAsync().ConfigureAwait(false);
            return ResidentialCarePackageFactory.ToDomain(result);
        }
    }
}
