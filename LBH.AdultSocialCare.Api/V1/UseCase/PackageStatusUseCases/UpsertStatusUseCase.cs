using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
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
            var statusEntity = status.ToEntity();
            statusEntity = await _gateway.UpsertAsync(statusEntity).ConfigureAwait(false);
            return statusEntity?.ToDomain();
        }
    }
}
