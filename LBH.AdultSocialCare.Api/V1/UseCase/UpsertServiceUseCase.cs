using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
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
