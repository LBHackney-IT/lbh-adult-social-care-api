using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
