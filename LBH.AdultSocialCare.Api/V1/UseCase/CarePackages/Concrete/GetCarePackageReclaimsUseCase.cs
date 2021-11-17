using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

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
            var result = await _carePackageReclaimGateway.GetListAsync(carePackageId, reclaimType, reclaimSubType);
            return result.ToDomain();
        }
    }
}
