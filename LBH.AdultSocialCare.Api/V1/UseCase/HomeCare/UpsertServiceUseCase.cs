using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class UpsertServiceUseCase : IUpsertServiceUseCase
    {
        private readonly IHomeCareServiceTypeGateway _typeGateway;

        public UpsertServiceUseCase(IHomeCareServiceTypeGateway homeCareServiceTypeGateway)
        {
            _typeGateway = homeCareServiceTypeGateway;
        }

        public async Task<HomeCareServiceDomain> ExecuteAsync(HomeCareServiceDomain homeCareService)
        {
            var serviceEntity = homeCareService.ToEntity();
            serviceEntity = await _typeGateway.UpsertAsync(serviceEntity).ConfigureAwait(false);
            return serviceEntity?.ToDomain();
        }
    }
}
