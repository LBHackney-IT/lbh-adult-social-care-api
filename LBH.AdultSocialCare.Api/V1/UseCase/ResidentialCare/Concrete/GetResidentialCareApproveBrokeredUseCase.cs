using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete
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
