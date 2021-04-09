using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class GetAllHomeCarePackageUseCase : IGetAllHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _gateway;
        public GetAllHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway)
        {
            _gateway = homeCarePackageGateway;
        }
        public async Task<IList<HomeCarePackage>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
