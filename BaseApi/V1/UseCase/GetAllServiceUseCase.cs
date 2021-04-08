using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetAllServiceUseCase : IGetAllServiceUseCase
    {
        private readonly IServiceGateway _gateway;
        public GetAllServiceUseCase(IServiceGateway serviceGateway)
        {
            _gateway = serviceGateway;
        }

        public async Task<IList<PackageServices>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
