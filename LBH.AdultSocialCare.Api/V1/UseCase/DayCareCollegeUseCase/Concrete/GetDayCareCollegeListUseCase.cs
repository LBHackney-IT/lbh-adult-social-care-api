using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Concrete
{
    public class GetDayCareCollegeListUseCase : IGetDayCareCollegeListUseCase
    {
        private readonly IDayCareCollegeGateway _dayCareCollegeGateway;

        public GetDayCareCollegeListUseCase(IDayCareCollegeGateway dayCareCollegeGateway)
        {
            _dayCareCollegeGateway = dayCareCollegeGateway;
        }

        public async Task<IEnumerable<DayCareCollegeResponse>> Execute()
        {
            var dayCarePackages = await _dayCareCollegeGateway.GetDayCareCollegeList().ConfigureAwait(false);
            return dayCarePackages.ToResponse();
        }
    }
}
