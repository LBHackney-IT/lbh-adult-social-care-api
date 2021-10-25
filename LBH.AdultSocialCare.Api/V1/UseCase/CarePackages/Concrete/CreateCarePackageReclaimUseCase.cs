using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateCarePackageReclaimUseCase : ICreateCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public CreateCarePackageReclaimUseCase(ICarePackageReclaimGateway carePackageReclaimGateway, ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task<CarePackageReclaimResponse> CreateCarePackageReclaim(CarePackageReclaimCreationDomain reclaimCreationDomain, ReclaimType reclaimType)
        {
            var carePackage = await _carePackageGateway.GetPackageAsync(reclaimCreationDomain.CarePackageId, PackageFields.Details).EnsureExistsAsync($"Care package with id {reclaimCreationDomain.CarePackageId} not found");
            var coreCostDetail = carePackage.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost).EnsureExists($"Core cost for package with id {reclaimCreationDomain.CarePackageId} not found");

            if (reclaimCreationDomain.SubType == ReclaimSubType.CareChargeProvisional)
            {
                if (coreCostDetail != null) reclaimCreationDomain.StartDate = coreCostDetail.StartDate;
            }

            // Validate FNC
            if (reclaimType == ReclaimType.Fnc)
            {
                // Check if FNC already added to package
                var packageFnc = await _carePackageGateway.GetCarePackageReclaimsAsync(
                    reclaimCreationDomain.CarePackageId, ReclaimType.Fnc, reclaimCreationDomain.SubType, false);
                if (packageFnc.Count > 0)
                {
                    throw new ApiException(
                        $"FNC already added to package with id {reclaimCreationDomain.CarePackageId}", HttpStatusCode.Conflict);
                }

                if (!reclaimCreationDomain.StartDate.IsInRange(coreCostDetail.StartDate, coreCostDetail.EndDate ?? DateTimeOffset.Now.AddYears(10)))
                {
                    throw new ApiException($"FNC start date must be equal or greater than {coreCostDetail.StartDate}", HttpStatusCode.UnprocessableEntity);
                }

                if (reclaimCreationDomain.EndDate != null)
                {
                    var fncEndDate = (DateTimeOffset) reclaimCreationDomain.EndDate;
                    if (coreCostDetail.EndDate != null && !fncEndDate.IsInRange(coreCostDetail.StartDate, (DateTimeOffset) coreCostDetail.EndDate))
                    {
                        throw new ApiException(
                            $"FNC end date is invalid. Must be in the range {coreCostDetail.StartDate} - {coreCostDetail.EndDate}", HttpStatusCode.UnprocessableEntity);
                    }
                }
            }

            var carePackageReclaim = reclaimCreationDomain.ToEntity();
            carePackageReclaim.Type = reclaimType;

            await _carePackageReclaimGateway.CreateAsync(carePackageReclaim);
            await _dbManager.SaveAsync("Could not save care package reclaim to database");
            return carePackageReclaim.ToDomain().ToResponse();
        }
    }
}
