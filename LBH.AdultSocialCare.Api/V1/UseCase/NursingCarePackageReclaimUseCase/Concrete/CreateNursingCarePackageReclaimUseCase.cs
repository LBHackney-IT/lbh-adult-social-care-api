using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Concrete
{
    public class CreateNursingCarePackageReclaimUseCase : ICreateNursingCarePackageReclaimUseCase
    {
        private readonly INursingCarePackageReclaimGateway _nursingCarePackageReclaimGateway;

        public CreateNursingCarePackageReclaimUseCase(INursingCarePackageReclaimGateway nursingCarePackageReclaimGateway)
        {
            _nursingCarePackageReclaimGateway = nursingCarePackageReclaimGateway;
        }

        public async Task<NursingCarePackageClaimResponse> ExecuteAsync(NursingCarePackageClaimCreationDomain nursingCarePackageClaimCreationDomain)
        {
            var dayCarePackageClaimEntity = nursingCarePackageClaimCreationDomain.ToDb();
            var res = await _nursingCarePackageReclaimGateway.CreateAsync(dayCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}