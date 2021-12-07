using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            if (res.Status == ReclaimStatus.Cancelled) res.HasAssessmentBeenCarried = false;
            return res.ToResponse();
        }

        public async Task<IEnumerable<CarePackageReclaimDomain>> GetListAsync(Guid carePackageId, ReclaimType? reclaimType, ReclaimSubType? reclaimSubType)
        {
            var result = await _carePackageReclaimGateway.GetListAsync(carePackageId, reclaimType, reclaimSubType);
            return result.ToDomain();
        }

        public async Task<CarePackageReclaimResponse> GetProvisionalCareCharge(Guid carePackageId)
        {
            var carePackage = await _carePackageGateway
                .GetPackageAsync(carePackageId, PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package with id {carePackageId} not found");

            var provisionalCareChargeReclaim =
                carePackage.Reclaims.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeProvisional);

            var res = provisionalCareChargeReclaim.ToDomain();

            if (carePackage.Reclaims.Any())
                res.HasAssessmentBeenCarried =
                    carePackage.Reclaims.Any(cc => cc.SubType != ReclaimSubType.CareChargeProvisional);

            return res.ToResponse();
        }

        public async Task<FinancialAssessmentViewResponse> GetFinancialAssessmentDetailsAsync(Guid carePackageId)
        {
            var package = await _carePackageGateway.GetPackageAsync(carePackageId, PackageFields.Reclaims | PackageFields.Resources, false)
                .EnsureExistsAsync($"Care package with id {carePackageId} not found");

            var validStatuses = new[] { ReclaimStatus.Pending, ReclaimStatus.Active, ReclaimStatus.Ended };

            var existingReclaims = package.Reclaims
                .Where(pr => pr.Type == ReclaimType.CareCharge && validStatuses.Contains(pr.Status))
                .OrderBy(pr => pr.StartDate).ToList();

            var resource = package.Resources.OrderByDescending(pr => pr.DateCreated).FirstOrDefault();

            return new FinancialAssessmentViewResponse
            {
                CareCharges = existingReclaims.ToDomain().ToResponse(),
                Resource = resource.ToDomain().ToResponse()
            };
        }
    }
}
