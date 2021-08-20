using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Concrete
{
    public class CreateDayCarePackageReclaimUseCase : ICreateDayCarePackageReclaimUseCase
    {
        private readonly IDayCarePackageReclaimGateway _dayCarePackageReclaimGateway;

        public CreateDayCarePackageReclaimUseCase(IDayCarePackageReclaimGateway dayCarePackageReclaimGateway)
        {
            _dayCarePackageReclaimGateway = dayCarePackageReclaimGateway;
        }

        public async Task<DayCarePackageClaimResponse> ExecuteAsync(DayCarePackageClaimCreationDomain dayCarePackageClaimCreationDomain)
        {
            var dayCarePackageClaimEntity = dayCarePackageClaimCreationDomain.ToDb();
            var res = await _dayCarePackageReclaimGateway.CreateAsync(dayCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
