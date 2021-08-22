using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
{
    public class GetAllHomeCarePackageUseCase : IGetAllHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _homeCarePackageGateway;

        public GetAllHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway)
        {
            _homeCarePackageGateway = homeCarePackageGateway;
        }

        public async Task<IList<HomeCarePackage>> GetAllAsync()
        {
            var homeCarePackages = await _homeCarePackageGateway.ListAsync().ConfigureAwait(false);
            return homeCarePackages;
        }
    }
}
