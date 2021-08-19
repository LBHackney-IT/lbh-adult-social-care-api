using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Concrete
{
    public class CreateHomeCarePackageReclaimUseCase : ICreateHomeCarePackageReclaimUseCase
    {
        private readonly IHomeCarePackageReclaimGateway _homeCarePackageReclaimGateway;

        public CreateHomeCarePackageReclaimUseCase(IHomeCarePackageReclaimGateway homeCarePackageReclaimGateway)
        {
            _homeCarePackageReclaimGateway = homeCarePackageReclaimGateway;
        }

        public async Task<HomeCarePackageClaimResponse> ExecuteAsync(HomeCarePackageClaimCreationDomain homeCarePackageClaimCreationDomain)
        {
            var homeCarePackageClaimEntity = homeCarePackageClaimCreationDomain.ToDb();
            var res = await _homeCarePackageReclaimGateway.CreateAsync(homeCarePackageClaimEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
