using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class DeleteHomeCarePackageSlotsUseCase : IDeleteHomeCarePackageSlotsUseCase
    {
        private readonly IHomeCarePackageSlotsGateway _gateway;
        public DeleteHomeCarePackageSlotsUseCase(IHomeCarePackageSlotsGateway homeCarePackageSlotsGateway)
        {
            _gateway = homeCarePackageSlotsGateway;
        }

        public async Task<bool> DeleteAsync(Guid homeCarePackageId)
        {
            return await _gateway.DeleteAsync(homeCarePackageId).ConfigureAwait(false);
        }
    }
}
