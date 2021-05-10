using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Concrete
{
    public class CreateResidentialCareRequestMoreInformationUseCase : ICreateResidentialCareRequestMoreInformationUseCase
    {
        private readonly IResidentialCareRequestMoreInformationGateway _requestMoreInformationGateway;

        public CreateResidentialCareRequestMoreInformationUseCase(IResidentialCareRequestMoreInformationGateway requestMoreInformationGateway)
        {
            _requestMoreInformationGateway = requestMoreInformationGateway;
        }

        public async Task<bool> Execute(ResidentialCareRequestMoreInformationDomain residentialCareRequestMoreInformation)
        {
            var residentialCareRequestMoreInformationEntity = residentialCareRequestMoreInformation.ToDb();
            //Todo send mail if succeed
            return await _requestMoreInformationGateway.CreateAsync(residentialCareRequestMoreInformationEntity).ConfigureAwait(false);
        }
    }
}