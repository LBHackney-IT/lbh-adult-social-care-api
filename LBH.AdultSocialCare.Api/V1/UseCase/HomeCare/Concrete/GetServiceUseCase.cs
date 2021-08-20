using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
{
    public class GetServiceUseCase : IGetServiceUseCase
    {
        private readonly IHomeCareServiceTypeGateway _typeGateway;

        public GetServiceUseCase(IHomeCareServiceTypeGateway homeCareServiceTypeGateway)
        {
            _typeGateway = homeCareServiceTypeGateway;
        }

        public async Task<HomeCareServiceDomain> GetAsync(int serviceId)
        {
            var packageEntity = await _typeGateway.GetAsync(serviceId).ConfigureAwait(false);

            return packageEntity?.ToDomain();
        }
    }
}
