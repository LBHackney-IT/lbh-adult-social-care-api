using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetStatusUseCase : IGetStatusUseCase
    {
        private readonly IStatusGateway _gateway;
        public GetStatusUseCase(IStatusGateway roleGateway)
        {
            _gateway = roleGateway;
        }
        public async Task<StatusDomain> GetAsync(Guid statusId)
        {
            var statusEntity = await _gateway.GetAsync(statusId).ConfigureAwait(false);
            return StatusFactory.ToDomain(statusEntity);
        }
    }
}
