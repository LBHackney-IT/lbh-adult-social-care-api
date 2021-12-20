using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateProvisionalCareChargeUseCase : ICreateProvisionalCareChargeUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public CreateProvisionalCareChargeUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task<CarePackageReclaimResponse> CreateProvisionalCareCharge(CarePackageReclaimCreationDomain reclaimCreationDomain, ReclaimType reclaimType)
        {
            var carePackage = await _carePackageGateway
                .GetPackageAsync(reclaimCreationDomain.CarePackageId, PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package with id {reclaimCreationDomain.CarePackageId} not found");

            if (carePackage.Status.In(PackageStatus.Cancelled, PackageStatus.Ended))
            {
                throw new ApiException($"Can not create {reclaimType.GetDisplayName()} for care package status {carePackage.Status.GetDisplayName()}",
                    HttpStatusCode.BadRequest);
            }

            var coreCostDetail = carePackage.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package with id {reclaimCreationDomain.CarePackageId} not found", HttpStatusCode.InternalServerError);

            ValidateProvisionalCareChargeAsync(reclaimCreationDomain, carePackage, coreCostDetail);

            //todo FK: ?
            reclaimCreationDomain.SubType = ReclaimSubType.CareChargeProvisional;
            var newReclaim = reclaimCreationDomain.ToEntity();

            //todo FK: ?
            newReclaim.Type = ReclaimType.CareCharge;
            newReclaim.Status = ReclaimStatus.Active;

            carePackage.Reclaims.Add(newReclaim);

            carePackage.Histories.Add(new CarePackageHistory
            {
                Description = $"{reclaimType.GetDisplayName()} {reclaimCreationDomain.SubType.GetDisplayName()} Created",
            });

            // Change status of package to submitted for approval
            if (carePackage.Status == PackageStatus.Approved)
            {
                carePackage.Status = PackageStatus.SubmittedForApproval;
            }

            await _dbManager.SaveAsync("Could not save care package reclaim to database");
            return newReclaim.ToDomain().ToResponse();
        }

        private static void ValidateProvisionalCareChargeAsync(CarePackageReclaimCreationDomain reclaimCreationDomain, CarePackage carePackage, CarePackageDetail coreCostDetail)
        {
            var validReclaimStatuses = new[] { ReclaimStatus.Active, ReclaimStatus.Pending, ReclaimStatus.Ended };
            if (reclaimCreationDomain.SubType != ReclaimSubType.CareChargeProvisional)
            {
                throw new ApiException($"Cannot create {reclaimCreationDomain.SubType.GetDisplayName()}. Manage other care charges types in the Care Charges menu",
                    HttpStatusCode.BadRequest);
            }

            if (carePackage.Reclaims.Any(cc => cc.Type == ReclaimType.CareCharge && cc.SubType == ReclaimSubType.CareChargeProvisional && cc.Status.In(validReclaimStatuses)))
            {
                throw new ApiException($"Provisional Care charge assessment for this package already done",
                    HttpStatusCode.BadRequest);
            }

            if (carePackage.Reclaims.Any(cc => cc.Type == ReclaimType.CareCharge && cc.SubType != ReclaimSubType.CareChargeProvisional))
            {
                throw new ApiException($"Care charge assessment for this package already done. Manage care charges for this package in the Care Charges menu",
                    HttpStatusCode.BadRequest);
            }

            // Start date of provisional CC cannot be before package start date
            if (!reclaimCreationDomain.StartDate.IsInRange(coreCostDetail.StartDate, coreCostDetail.EndDate ?? DateTimeOffset.Now.AddYears(10)))
            {
                throw new ApiException($"{ReclaimSubType.CareChargeProvisional.GetDisplayName()} start date must be equal or greater than {coreCostDetail.StartDate.Date}", HttpStatusCode.UnprocessableEntity);
            }

            // End date of provisional CC cannot be before package end date
            if (reclaimCreationDomain.EndDate != null)
            {
                var provisionalCareChargeEndDate = (DateTimeOffset) reclaimCreationDomain.EndDate;
                if (coreCostDetail.EndDate != null && !provisionalCareChargeEndDate.IsInRange(coreCostDetail.StartDate, (DateTimeOffset) coreCostDetail.EndDate))
                {
                    throw new ApiException(
                        $"{reclaimCreationDomain.SubType} end date is invalid. Must be in the range {coreCostDetail.StartDate} - {coreCostDetail.EndDate}", HttpStatusCode.UnprocessableEntity);
                }
            }

            // If provisional cc is set to be ongoing, force end date to be the end date of the package
            if (coreCostDetail.EndDate != null && reclaimCreationDomain.EndDate == null)
            {
                reclaimCreationDomain.EndDate = coreCostDetail.EndDate;
            }
        }
    }
}
