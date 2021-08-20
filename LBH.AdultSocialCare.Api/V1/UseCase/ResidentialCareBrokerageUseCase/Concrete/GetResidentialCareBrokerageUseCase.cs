using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Concrete
{
    public class GetResidentialCareBrokerageUseCase : IGetResidentialCareBrokerageUseCase
    {
        private readonly IResidentialCareBrokerageGateway _residentialCareBrokerageGateway;

        public GetResidentialCareBrokerageUseCase(IResidentialCareBrokerageGateway residentialCareBrokerageGateway)
        {
            _residentialCareBrokerageGateway = residentialCareBrokerageGateway;
        }

        public async Task<ResidentialCareBrokerageInfoResponse> Execute(Guid residentialCarePackageId)
        {
            var residentialCareBrokerageInfo = await _residentialCareBrokerageGateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);
            return residentialCareBrokerageInfo.ToResponse();
        }
    }
}
