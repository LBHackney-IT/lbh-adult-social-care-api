using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Concrete
{
    public class CreateResidentialCareBrokerageUseCase : ICreateResidentialCareBrokerageUseCase
    {
        private readonly IResidentialCareBrokerageGateway _residentialCareBrokerageGateway;

        public CreateResidentialCareBrokerageUseCase(IResidentialCareBrokerageGateway residentialCareBrokerageGateway)
        {
            _residentialCareBrokerageGateway = residentialCareBrokerageGateway;
        }

        public async Task<ResidentialCareBrokerageInfoResponse> ExecuteAsync(ResidentialCareBrokerageInfoCreationDomain residentialCareBrokerageInfoCreationDomain)
        {
            var brokerageInfo = await _residentialCareBrokerageGateway.GetAsync(residentialCareBrokerageInfoCreationDomain.ResidentialCarePackageId).ConfigureAwait(false);

            if (brokerageInfo.Id != Guid.Empty)
            {
                throw new ApiException($"A brokerage for residential care package {residentialCareBrokerageInfoCreationDomain.ResidentialCarePackageId} already exists");
            }

            var residentialCareBrokerageInfoEntity = residentialCareBrokerageInfoCreationDomain.ToDb();
            var res = await _residentialCareBrokerageGateway.CreateAsync(residentialCareBrokerageInfoEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
