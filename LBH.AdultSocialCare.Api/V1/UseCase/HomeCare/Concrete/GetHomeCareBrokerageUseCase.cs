using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
