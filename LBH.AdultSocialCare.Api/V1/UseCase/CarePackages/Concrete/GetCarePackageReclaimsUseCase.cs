using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCarePackageReclaimsUseCase : IGetCarePackageReclaimsUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;
        private readonly ICarePackageGateway _carePackageGateway;

        public GetCarePackageReclaimsUseCase(ICarePackageReclaimGateway carePackageReclaimGateway, ICarePackageGateway carePackageGateway)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
            _carePackageGateway = carePackageGateway;
        }

        public async Task<CarePackageReclaimResponse> GetCarePackageReclaim(Guid carePackageId, ReclaimType reclaimType)
        {
            var res = await _carePackageReclaimGateway.GetSingleAsync(carePackageId, reclaimType);
            return res.ToResponse();
        }

        public async Task<IEnumerable<CarePackageReclaimDomain>> GetListAsync(Guid carePackageId, ReclaimType? reclaimType, ReclaimSubType? reclaimSubType)
        {
            await _carePackageGateway.GetPackageAsync(carePackageId)
                .EnsureExistsAsync($"Care package {carePackageId} not found");

            var result = await _carePackageReclaimGateway.GetListAsync(carePackageId, reclaimType, reclaimSubType);
            return result.ToDomain();
        }
    }
}
