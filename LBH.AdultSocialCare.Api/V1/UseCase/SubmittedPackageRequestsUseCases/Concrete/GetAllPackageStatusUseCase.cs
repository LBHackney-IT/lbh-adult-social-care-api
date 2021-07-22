using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.SubmittedPackageRequestsGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Concrete
{
    public class GetAllPackageStatusUseCase : IGetAllPackageStatusUseCase
    {
        private readonly ISubmittedPackageRequestsGateway _submittedPackageRequestsGateway;

        public GetAllPackageStatusUseCase(ISubmittedPackageRequestsGateway submittedPackageRequestsGateway)
        {
            _submittedPackageRequestsGateway = submittedPackageRequestsGateway;
        }

        public async Task<IEnumerable<StatusResponse>> GetAllAsync()
        {
            var result = await _submittedPackageRequestsGateway.GetSubmittedPackageRequestsStatus().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
