using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageStatusUseCases
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
            PackageStatus statusEntity = StatusFactory.ToEntity(status);
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
