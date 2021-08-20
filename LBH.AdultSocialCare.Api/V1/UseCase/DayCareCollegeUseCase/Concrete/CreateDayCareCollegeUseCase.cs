using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCareCollegeGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Concrete
{
    public class CreateDayCareCollegeUseCase : ICreateDayCareCollegeUseCase
    {
        private readonly IDayCareCollegeGateway _dayCareCollegeGateway;

        public CreateDayCareCollegeUseCase(IDayCareCollegeGateway dayCareCollegeGateway)
        {
            _dayCareCollegeGateway = dayCareCollegeGateway;
        }

        public async Task<int> Execute(DayCareCollegeForCreationDomain dayCareCollegeForCreationDomain)
        {
            var dayCareCollegeEntity = dayCareCollegeForCreationDomain.ToDb();
            var id = await _dayCareCollegeGateway.CreateDayCareCollege(dayCareCollegeEntity).ConfigureAwait(false);
            return id;
        }
    }
}
