using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpsertStatusUseCase : IUpsertStatusUseCase
    {
        private readonly IStatusGateway _gateway;
        public UpsertStatusUseCase(IStatusGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<StatusDomain> ExecuteAsync(StatusDomain status)
        {
            Status statusEntity = StatusFactory.ToEntity(status);
            statusEntity = await _gateway.UpsertAsync(statusEntity).ConfigureAwait(false);
            if (statusEntity == null) return status = null;
            else
            {
                status = StatusFactory.ToDomain(statusEntity);
            }
            return status;
        }
    }
}
