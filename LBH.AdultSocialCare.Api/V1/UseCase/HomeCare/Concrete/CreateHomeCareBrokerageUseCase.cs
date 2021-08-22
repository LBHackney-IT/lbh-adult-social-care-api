using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
