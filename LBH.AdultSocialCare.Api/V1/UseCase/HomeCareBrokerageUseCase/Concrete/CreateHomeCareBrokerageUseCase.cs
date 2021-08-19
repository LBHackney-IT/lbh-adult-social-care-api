using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Concrete
{
    public class CreateHomeCareBrokerageUseCase : ICreateHomeCareBrokerageUseCase
    {
        private readonly IHomeCareBrokerageGateway _homeCareBrokerageGateway;

        public CreateHomeCareBrokerageUseCase(IHomeCareBrokerageGateway homeCareBrokerageGateway)
        {
            _homeCareBrokerageGateway = homeCareBrokerageGateway;
        }

        public async Task<HomeCareBrokerageResponse> ExecuteAsync(Guid homeCarePackageId, HomeCareBrokerageCreationDomain homeCareBrokerageCreationDomain)
        {
            var res = await _homeCareBrokerageGateway.CreateAsync(homeCarePackageId, homeCareBrokerageCreationDomain).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
