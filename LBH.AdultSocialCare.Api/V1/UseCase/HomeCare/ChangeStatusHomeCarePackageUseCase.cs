using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class ChangeStatusHomeCarePackageUseCase : IChangeStatusHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _gateway;

        public ChangeStatusHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway)
        {
            _gateway = homeCarePackageGateway;
        }

        public async Task<HomeCarePackageDomain> UpdateAsync(Guid homeCarePackageId, int statusId)
        {
            var homeCarePackageEntity = await _gateway.ChangeStatusAsync(homeCarePackageId, statusId).ConfigureAwait(false);
            return homeCarePackageEntity?.ToDomain();
        }
    }
}
