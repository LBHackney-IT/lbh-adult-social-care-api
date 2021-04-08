using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
