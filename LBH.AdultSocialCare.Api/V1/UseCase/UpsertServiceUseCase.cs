using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class UpsertServiceUseCase : IUpsertServiceUseCase
    {
        private readonly IHomeCareServiceTypeGateway _typeGateway;
        public UpsertServiceUseCase(IHomeCareServiceTypeGateway homeCareServiceTypeGateway)
        {
            _typeGateway = homeCareServiceTypeGateway;
        }
        public async Task<ServiceDomain> ExecuteAsync(ServiceDomain service)
        {
            HomeCareServiceType serviceEntity = ServiceFactory.ToEntity(service);
            serviceEntity = await _typeGateway.UpsertAsync(serviceEntity).ConfigureAwait(false);
            if (serviceEntity == null) return service = null;
            else
            {
                service = ServiceFactory.ToDomain(serviceEntity);
            }
            return service;
        }
    }
}
