using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class GetDayCarePackageForApprovalDetailsUseCase : IGetDayCarePackageForApprovalDetailsUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public GetDayCarePackageForApprovalDetailsUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<DayCarePackageForApprovalDetailsResponse> Execute(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dayCarePackageGateway.GetDayCarePackageForApprovalDetails(dayCarePackageId).ConfigureAwait(false);
            return dayCarePackage.ToResponse();
        }
    }
}
