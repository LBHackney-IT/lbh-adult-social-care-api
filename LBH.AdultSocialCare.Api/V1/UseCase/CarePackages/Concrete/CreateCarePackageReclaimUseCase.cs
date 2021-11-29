using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateCarePackageReclaimUseCase : ICreateCarePackageReclaimUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;

        public CreateCarePackageReclaimUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager, IMapper mapper, IFileStorage fileStorage)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public async Task<CarePackageReclaimResponse> CreateCarePackageReclaim(CarePackageReclaimCreationDomain reclaimCreationDomain, ReclaimType reclaimType)
        {
            var carePackage = await _carePackageGateway
                .GetPackageAsync(reclaimCreationDomain.CarePackageId, PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package with id {reclaimCreationDomain.CarePackageId} not found");

            var coreCostDetail = carePackage.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package with id {reclaimCreationDomain.CarePackageId} not found", HttpStatusCode.InternalServerError);

            CarePackageReclaim newReclaim = null;

            if (reclaimType is ReclaimType.Fnc)
            {
                await ValidateFncAsync(reclaimCreationDomain, coreCostDetail, carePackage);
            }
            else if (reclaimType is ReclaimType.CareCharge)
            {
                newReclaim = TryHandleProvisionalCareCharge(reclaimCreationDomain, coreCostDetail, carePackage);
            }

            if (reclaimType is ReclaimType.CareCharge)
            {
                ValidateCareChargeAsync(reclaimCreationDomain, coreCostDetail, carePackage);
            }

            if (newReclaim is null)
            {
                newReclaim = reclaimCreationDomain.ToEntity();
                newReclaim.Type = reclaimType;

                if (reclaimCreationDomain.AssessmentFileId == Guid.Empty)
                {
                    var documentResponse = await _fileStorage.SaveFileAsync
                        (ConvertCarePlan(reclaimCreationDomain.AssessmentFile), reclaimCreationDomain.AssessmentFile.FileName);
                    newReclaim.AssessmentFileId = documentResponse?.FileId ?? Guid.Empty;
                    newReclaim.AssessmentFileName = documentResponse?.FileName;
                }

                carePackage.Reclaims.Add(newReclaim);
            }

            carePackage.Histories.Add(new CarePackageHistory
            {
                Description = $"{newReclaim.Type.GetDisplayName()} Created",
            });

            // Change status of package to in-progress
            if (carePackage.Status != PackageStatus.InProgress)
            {
                carePackage.Status = PackageStatus.InProgress;
            }

            await _dbManager.SaveAsync("Could not save care package reclaim to database");
            return newReclaim.ToDomain().ToResponse();
        }

        private CarePackageReclaim TryHandleProvisionalCareCharge(CarePackageReclaimCreationDomain requestedReclaim, CarePackageDetail coreCostDetail, CarePackage carePackage)
        {
            var provisionalReclaim = carePackage.Reclaims
                .FirstOrDefault(r => r.SubType == ReclaimSubType.CareChargeProvisional &&
                                     r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending));

            if (requestedReclaim.SubType is ReclaimSubType.CareChargeProvisional)
            {
                requestedReclaim.StartDate = coreCostDetail.StartDate;

                // new provisional reclaim shouldn't be created, update existing instead
                if (provisionalReclaim != null)
                {
                    _mapper.Map(requestedReclaim, provisionalReclaim);
                    return provisionalReclaim;
                }
            }
            else
            {
                // some 'real' care charge is requested (1-12 wk / 13+ wk etc.) - end provisional reclaim if any
                // The provisional end date should be 1 day before start date of requested reclaim
                if (provisionalReclaim != null)
                {
                    provisionalReclaim.Status = ReclaimStatus.Ended;
                    provisionalReclaim.EndDate = requestedReclaim.StartDate.Date.AddDays(-1);
                }
            }

            return null;
        }

        private async Task ValidateFncAsync(CarePackageReclaimCreationDomain reclaimCreationDomain, CarePackageDetail coreCostDetail, CarePackage carePackage)
        {
            // Ensure package type is nursing care
            if (carePackage.PackageType != PackageType.NursingCare)
            {
                throw new ApiException(
                    $"FNC only allowed for nursing care package. Package with id {carePackage.Id} is invalid",
                    HttpStatusCode.BadRequest);
            }

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

        private static void ValidateCareChargeAsync(CarePackageReclaimCreationDomain requestedReclaim, CarePackageDetail coreCostDetail, CarePackage carePackage)
        {
            //care charges should be within corePackage.StartDate - corePackage.EndDate
            if (requestedReclaim.StartDate < coreCostDetail.StartDate)
            {
                throw new ApiException(
                    $"{requestedReclaim.SubType} start date is invalid. Must be in the range {coreCostDetail.StartDate} - {coreCostDetail.EndDate}", HttpStatusCode.UnprocessableEntity);
            }

            if (requestedReclaim.EndDate != null)
            {
                var careChargeEndDate = (DateTimeOffset) requestedReclaim.EndDate;
                if (coreCostDetail.EndDate != null && !careChargeEndDate.IsInRange(coreCostDetail.StartDate, (DateTimeOffset) coreCostDetail.EndDate))
                {
                    throw new ApiException(
                        $"{requestedReclaim.SubType} end date is invalid. Must be in the range {coreCostDetail.StartDate} - {coreCostDetail.EndDate}", HttpStatusCode.UnprocessableEntity);
                }
            }

            // Compare requested care charge dates with existing care charge dates
            if (requestedReclaim.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks)
            {
                var existingProvisionalCareCharge =
                    carePackage.Reclaims.FirstOrDefault(r => r.SubType == ReclaimSubType.CareChargeProvisional);

                if (existingProvisionalCareCharge != null)
                {
                    if (existingProvisionalCareCharge.EndDate != requestedReclaim.StartDate.Date.AddDays(-1))
                    {
                        throw new ApiException(
                            $"{requestedReclaim.SubType} start date is invalid. Date for {requestedReclaim.SubType} should be consecutive with previous care charge type",
                            HttpStatusCode.BadRequest);
                    }
                }
            }
            else if (requestedReclaim.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks)
            {
                var existingCareChargeWithoutPropertyOneToTwelveWeeks =
                    carePackage.Reclaims.Where(r => r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending))
                        .FirstOrDefault(r => r.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks);

                if (existingCareChargeWithoutPropertyOneToTwelveWeeks is null)
                {
                    throw new ApiException(
                        $"Cannot create {requestedReclaim.SubType} without {ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks.GetDisplayName()}",
                        HttpStatusCode.BadRequest);
                }

                // Calculate 12 weeks from startDate for EndDate of CareChargeWithoutPropertyOneToTwelveWeeks if it is null
                var propertyOneToTwelveWeeksEndDate = existingCareChargeWithoutPropertyOneToTwelveWeeks.EndDate ??
                                                      existingCareChargeWithoutPropertyOneToTwelveWeeks.StartDate.Date
                                                          .AddDays(12 * 7);

                if (propertyOneToTwelveWeeksEndDate.Date != requestedReclaim.StartDate.Date.AddDays(-1))
                {
                    throw new ApiException(
                        $"{requestedReclaim.SubType} start date is invalid. Date for {requestedReclaim.SubType} should be consecutive with previous care charge type",
                        HttpStatusCode.BadRequest);
                }
            }
        }

        private static string ConvertCarePlan(IFormFile carePlanFile)
        {
            if (carePlanFile != null)
            {
                using (var stream = new MemoryStream())
                {
                    carePlanFile.CopyTo(stream);

                    var bytes = stream.ToArray();
                    return $"data:{carePlanFile.ContentType};base64,{Convert.ToBase64String(bytes)}";
                }
            }

            return null;
        }
    }
}
