using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
