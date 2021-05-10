using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Concrete
{
    public class CreateDayCareRequestMoreInformationUseCase : ICreateDayCareRequestMoreInformationUseCase
    {
        private readonly IDayCareRequestMoreInformationGateway _requestMoreInformationGateway;

        public CreateDayCareRequestMoreInformationUseCase(IDayCareRequestMoreInformationGateway requestMoreInformationGateway)
        {
            _requestMoreInformationGateway = requestMoreInformationGateway;
        }

        public async Task<bool> Execute(DayCareRequestMoreInformationDomain dayCareRequestMoreInformation)
        {
            var dayCareRequestMoreInformationEntity = dayCareRequestMoreInformation.ToDb();
            //Todo send mail if succeed
            return await _requestMoreInformationGateway.CreateAsync(dayCareRequestMoreInformationEntity).ConfigureAwait(false);
        }
    }
}