using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
