using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Concrete
{
    public class CreateNursingCareRequestMoreInformationUseCase : ICreateNursingCareRequestMoreInformationUseCase
    {
        private readonly INursingCareRequestMoreInformationGateway _requestMoreInformationGateway;

        public CreateNursingCareRequestMoreInformationUseCase(INursingCareRequestMoreInformationGateway requestMoreInformationGateway)
        {
            _requestMoreInformationGateway = requestMoreInformationGateway;
        }

        public async Task<bool> Execute(NursingCareRequestMoreInformationDomain nursingCareRequestMoreInformation)
        {
            var nursingCareRequestMoreInformationEntity = nursingCareRequestMoreInformation.ToDb();
            //Todo send mail if succeed
            return await _requestMoreInformationGateway.CreateAsync(nursingCareRequestMoreInformationEntity).ConfigureAwait(false);
        }
    }
}
