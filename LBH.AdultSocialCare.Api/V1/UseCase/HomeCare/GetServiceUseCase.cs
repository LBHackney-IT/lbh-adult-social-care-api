using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{

    public class GetServiceUseCase : IGetServiceUseCase
    {

        private readonly IHomeCareServiceTypeGateway _typeGateway;

        public GetServiceUseCase(IHomeCareServiceTypeGateway homeCareServiceTypeGateway)
        {
            _typeGateway = homeCareServiceTypeGateway;
        }

        public async Task<ServiceDomain> GetAsync(int serviceId)
        {
            var packageEntity = await _typeGateway.GetAsync(serviceId).ConfigureAwait(false);

            return ServiceFactory.ToDomain(packageEntity);
        }

    }

}
