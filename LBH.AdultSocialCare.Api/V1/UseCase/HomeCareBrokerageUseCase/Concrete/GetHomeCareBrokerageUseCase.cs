using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Concrete
{
    public class GetHomeCareBrokerageUseCase : IGetHomeCareBrokerageUseCase
    {
        private readonly IHomeCareBrokerageGateway _homeCareBrokerageGateway;

        public GetHomeCareBrokerageUseCase(IHomeCareBrokerageGateway homeCareBrokerageGateway)
        {
            _homeCareBrokerageGateway = homeCareBrokerageGateway;
        }

        public async Task<HomeCareBrokerageResponse> Execute(Guid homeCarePackageId)
        {
            var homeCareBrokerage = await _homeCareBrokerageGateway.GetAsync(homeCarePackageId).ConfigureAwait(false);
            return homeCareBrokerage.ToResponse();
        }
    }
}
