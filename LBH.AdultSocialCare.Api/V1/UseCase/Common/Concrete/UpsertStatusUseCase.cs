using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
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
