using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases
{
    public class GetAllResidentialCareHomeType : IGetAllResidentialCareHomeType
    {
        private readonly IResidentialCarePackageGateway _gateway;
        public GetAllResidentialCareHomeType(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<IList<TypeOfResidentialCareHomeDomain>> GetAllAsync()
        {
            var result = await _gateway.GetListOfTypeOfResidentialCareHomeAsync().ConfigureAwait(false);
            return ResidentialCarePackageFactory.ToDomain(result);
        }
    }
}
