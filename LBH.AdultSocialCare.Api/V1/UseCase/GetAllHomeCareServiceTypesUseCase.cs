using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
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
