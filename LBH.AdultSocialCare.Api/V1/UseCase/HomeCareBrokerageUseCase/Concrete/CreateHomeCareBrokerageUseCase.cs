using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
