using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
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
