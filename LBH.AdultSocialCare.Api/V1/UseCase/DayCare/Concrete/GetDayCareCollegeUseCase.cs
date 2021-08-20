using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Concrete
{
    public class GetDayCareCollegeUseCase : IGetDayCareCollegeUseCase
    {
        private readonly IDayCareCollegeGateway _dayCareCollegeGateway;

        public GetDayCareCollegeUseCase(IDayCareCollegeGateway dayCareCollegeGateway)
        {
            _dayCareCollegeGateway = dayCareCollegeGateway;
        }

        public async Task<DayCareCollegeResponse> Execute(int dayCareCollegeId)
        {
            var dayCarePackage = await _dayCareCollegeGateway.GetDayCareCollege(dayCareCollegeId).ConfigureAwait(false);
            return dayCarePackage.ToResponse();
        }
    }
}
