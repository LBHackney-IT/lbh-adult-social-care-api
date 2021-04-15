using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class GetAllHomeCareServiceTypesUseCase : IGetAllHomeCareServiceTypesUseCase
    {
        private readonly IHomeCareServiceTypeGateway _typeGateway;
        public GetAllHomeCareServiceTypesUseCase(IHomeCareServiceTypeGateway homeCareServiceTypeGateway)
        {
            _typeGateway = homeCareServiceTypeGateway;
        }

        public async Task<IList<HomeCareServiceType>> GetAllAsync()
        {
            return await _typeGateway.ListAsync().ConfigureAwait(false);
        }
    }
}
