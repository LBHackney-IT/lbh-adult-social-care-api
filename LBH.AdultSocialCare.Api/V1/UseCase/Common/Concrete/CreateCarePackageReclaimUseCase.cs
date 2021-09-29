using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CreateCarePackageReclaimUseCase : ICreateCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;

        public CreateCarePackageReclaimUseCase(ICarePackageReclaimGateway carePackageReclaimGateway)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
        }

        public async Task<CarePackageReclaimResponse> CreateCarePackageReclaim(CarePackageReclaimCreationDomain carePackageReclaimCreationDomain)
        {
            var carePackageReclaim = carePackageReclaimCreationDomain.ToEntity();
            var res = await _carePackageReclaimGateway.CreateAsync(carePackageReclaim);
            return res.ToResponse();
        }
    }
}
