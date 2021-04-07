using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpsertServiceUseCase : IUpsertServiceUseCase
    {
        private readonly IServiceGateway _gateway;
        public UpsertServiceUseCase(IServiceGateway serviceGateway)
        {
            _gateway = serviceGateway;
        }
        public async Task<ServiceDomain> ExecuteAsync(ServiceDomain service)
        {
            PackageServices serviceEntity = ServiceFactory.ToEntity(service);
            serviceEntity = await _gateway.UpsertAsync(serviceEntity).ConfigureAwait(false);
            if (serviceEntity == null) return service = null;
            else
            {
                service = ServiceFactory.ToDomain(serviceEntity);
            }
            return service;
        }
    }
}
