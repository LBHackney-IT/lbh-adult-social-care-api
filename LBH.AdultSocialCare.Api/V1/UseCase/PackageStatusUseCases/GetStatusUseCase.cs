using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageStatusUseCases
{
    public class GetStatusUseCase : IGetStatusUseCase
    {
        private readonly IStatusGateway _gateway;
        public GetStatusUseCase(IStatusGateway roleGateway)
        {
            _gateway = roleGateway;
        }
        public async Task<StatusDomain> GetAsync(int statusId)
        {
            var statusEntity = await _gateway.GetAsync(statusId).ConfigureAwait(false);
            return StatusFactory.ToDomain(statusEntity);
        }
    }
}
