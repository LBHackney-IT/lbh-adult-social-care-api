using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Concrete
{
    public class CreateHomeCareRequestMoreInformationUseCase : ICreateHomeCareRequestMoreInformationUseCase
    {
        private readonly IHomeCareRequestMoreInformationGateway _requestMoreInformationGateway;

        public CreateHomeCareRequestMoreInformationUseCase(IHomeCareRequestMoreInformationGateway requestMoreInformationGateway)
        {
            _requestMoreInformationGateway = requestMoreInformationGateway;
        }

        public async Task<bool> Execute(HomeCareRequestMoreInformationDomain homeCareRequestMoreInformation)
        {
            var homeCareRequestMoreInformationEntity = homeCareRequestMoreInformation.ToDb();
            //Todo send mail if succeed
            return await _requestMoreInformationGateway.CreateAsync(homeCareRequestMoreInformationEntity).ConfigureAwait(false);
        }
    }
}
