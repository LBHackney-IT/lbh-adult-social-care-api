using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class GetServiceUseCase : IGetServiceUseCase
    {
        private readonly IServiceGateway _gateway;
        public GetServiceUseCase(IServiceGateway serviceGateway)
        {
            _gateway = serviceGateway;
        }
        public async Task<ServiceDomain> GetAsync(Guid serviceId)
        {
            var packageEntity = await _gateway.GetAsync(serviceId).ConfigureAwait(false);
            return ServiceFactory.ToDomain(packageEntity);
        }
    }
}
