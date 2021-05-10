using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Concrete
{
    public class GetResidentialCareApproveBrokeredUseCase : IGetResidentialCareApproveBrokeredUseCase
    {
        private readonly IResidentialCareApproveBrokeredGateway _residentialCareApproveBrokeredGateway;

        public GetResidentialCareApproveBrokeredUseCase(IResidentialCareApproveBrokeredGateway residentialCareApproveBrokeredGateway)
        {
            _residentialCareApproveBrokeredGateway = residentialCareApproveBrokeredGateway;
        }

        public async Task<ResidentialCareApproveBrokeredResponse> Execute(Guid residentialCarePackageId)
        {
            var residentialCareApproveBrokered = await _residentialCareApproveBrokeredGateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);
            return residentialCareApproveBrokered.ToResponse();
        }
    }
}