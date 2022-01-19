using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpsertCareChargesUseCase : IUpsertCareChargesUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IMapper _mapper;

        public UpsertCareChargesUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager, IMapper mapper)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(Guid carePackageId, CareChargesCreateDomain request)
        {
            // Get package with all reclaims
            var package = await _carePackageGateway
                .GetPackageAsync(carePackageId, PackageFields.Settings | PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package with id {carePackageId} not found");

            ValidatePackage(package);
            ValidateRequestIntegrity(request, package); // ensure existing reclaims match requested

            // since validating raw request is tricky, first build a model of ordered charges
            // and then validate them to be in package date range and followed each other without any gaps
            PrepareCareChargesModel(request, package);
            ValidateCareChargesModel(request, package);

            // if care charge has date / cost / collector changed, cancel existing one and replace it with new.
            ReplaceUpdatedCareCharges(request, package);
            ReclaimCostValidator.Validate(package);

            await _dbManager.SaveAsync();
        }

        private static void PrepareCareChargesModel(CareChargesCreateDomain request, CarePackage package)
        {
            foreach (var careCharge in request.CareCharges)
            {
                careCharge.CarePackageId = package.Id;
            }

            var coreCost = package.GetCoreCostDetail();

            // Limit ongoing charges if package interval is finite
            request.CareCharges = request.CareCharges.OrderBy(cc => cc.SubType).ToList();

            if (request.CareCharges.Last().EndDate is null && coreCost.EndDate != null)
            {
                request.CareCharges.Last().EndDate = coreCost.EndDate;
            }

            // if requested 1-12 charge covers period of provisional charge, 1-12 will replace provisional
            var provisionalCharge = request.CareCharges.SingleOrDefault(cc => cc.SubType is ReclaimSubType.CareChargeProvisional);
            var first12WeeksCharge = request.CareCharges.SingleOrDefault(cc => cc.SubType is ReclaimSubType.CareCharge1To12Weeks);

            if (first12WeeksCharge != null && first12WeeksCharge.StartDate.Date <= provisionalCharge?.StartDate.Date)
            {
                provisionalCharge.Status = ReclaimStatus.Cancelled;
            }
        }

        private static void ValidatePackage(CarePackage package)
        {
            if (package.Settings.IsS117Client)
            {
                throw new ApiException("Cannot add add care charges for service user under S1117", HttpStatusCode.BadRequest);
            }

            if (package.Status.In(PackageStatus.Cancelled, PackageStatus.Ended))
            {
                throw new ApiException($"Cannot edit care charges for care package in status {package.Status.GetDisplayName()}", HttpStatusCode.BadRequest);
            }

            if (package.GetCoreCostDetail() is null)
            {
                throw new ApiException("Core cost must be defined before editing care charges", HttpStatusCode.BadRequest);
            }
        }

        private static void ValidateCareChargesModel(CareChargesCreateDomain request, CarePackage package)
        {
            Debug.Assert(ReclaimSubType.CareChargeProvisional == ReclaimSubType.CareCharge1To12Weeks - 1);
            Debug.Assert(ReclaimSubType.CareCharge1To12Weeks == ReclaimSubType.CareCharge13PlusWeeks - 1);

            var coreCost = package.GetCoreCostDetail();

            var requestedCareCharges = request.CareCharges
                .Where(c => c.Status != ReclaimStatus.Cancelled)
                .OrderBy(c => c.SubType).ToList();

            // Care charges should follow each other without gaps
            for (var i = 1; i < requestedCareCharges.Count; i++)
            {
                var currentCharge = requestedCareCharges[i];
                var previousCharge = requestedCareCharges[i - 1];

                if (!package.IsMigrated && currentCharge.SubType != previousCharge.SubType + 1)
                {
                    throw new ApiException($"{GetShortName(previousCharge.SubType)} care charge must be followed by" +
                                           $" {GetShortName(previousCharge.SubType + 1)}", HttpStatusCode.BadRequest);
                }

                var expectedEndDate = currentCharge.StartDate.Date.AddDays(-1);
                if (previousCharge.EndDate is null)
                {
                    throw new ApiException($"{GetShortName(previousCharge.SubType)} care charge must have an end date one day before " +
                                           $"{GetShortName(currentCharge.SubType)} start: {expectedEndDate:yyy-MM-dd}", HttpStatusCode.BadRequest);
                }

                var expectedStartDate = previousCharge.EndDate.Value.Date.AddDays(1);
                if (currentCharge.StartDate.Date != expectedStartDate)
                {
                    throw new ApiException($"{GetShortName(currentCharge.SubType)} care charge must start one day after " +
                                           $"{GetShortName(previousCharge.SubType)} care charge end: {expectedStartDate:yyy-MM-dd}", HttpStatusCode.BadRequest);
                }
            }

            // First care charge must be started at package start date
            if (requestedCareCharges.First()?.StartDate.Date < coreCost.StartDate.Date)
            {
                throw new ApiException("First care charge start date must be greater or equal to package start date " +
                                       $"{coreCost.StartDate:yyyy-MM-dd}", HttpStatusCode.BadRequest);
            }

            // Last care charge end date must not exceed package end date (if any)
            if (coreCost.EndDate.HasValue && requestedCareCharges.Last().EndDate?.Date > coreCost.EndDate.Value.Date)
            {
                throw new ApiException("Last care charge end date expected to be less than or equal " +
                                       $"to {coreCost.EndDate.Value:yyyy-MM-dd}", HttpStatusCode.BadRequest);
            }

            ValidateCareChargeBounds(requestedCareCharges);
        }

        private static void ValidateCareChargeBounds(List<CareChargeReclaimCreationDomain> careCharges)
        {
            foreach (var careCharge in careCharges)
            {
                if (careCharge.StartDate > careCharge.EndDate)
                {
                    throw new ApiException($"{GetShortName(careCharge.SubType)} charge start date should be less than or equal to its end date");
                }
            }

            // 1-12 care charge duration shouldn't exceed 12 weeks
            var first12WeeksCharge = careCharges.SingleOrDefault(cc => cc.SubType is ReclaimSubType.CareCharge1To12Weeks);
            if (first12WeeksCharge != null)
            {
                var realEndDate = first12WeeksCharge.EndDate.GetValueOrDefault().Date;
                var maxEndDate = first12WeeksCharge.StartDate.Date.AddDays(12 * 7 - 1); // 12 weeks, exclude last day to get inclusive 84 days range

                if (realEndDate > maxEndDate)
                {
                    throw new ApiException("1-12 weeks care charge duration cannot exceed 12 weeks. Max end date is " +
                                           $"{maxEndDate:yyyy-MM-dd}", HttpStatusCode.BadRequest);
                }
            }
        }

        private static void ValidateRequestIntegrity(CareChargesCreateDomain request, CarePackage package)
        {
            var existingCareCharges = package.Reclaims
                .Where(r => r.Type is ReclaimType.CareCharge &&
                            r.Status.In(ReclaimStatus.Pending, ReclaimStatus.Active, ReclaimStatus.Ended))
                .ToList();

            // each existing care charge should be presented in upsert request
            var missedCareCharges = existingCareCharges
                .Where(existingCharge => !request.CareCharges.Any(
                    requestedCharge =>
                        requestedCharge.SubType == existingCharge.SubType &&
                        requestedCharge.Id == existingCharge.Id))
                .Select(existingCareCharge => GetShortName(existingCareCharge.SubType))
                .ToList();

            if (missedCareCharges.Count > 0)
            {
                throw new ApiException($"Care charges {String.Join(", ", missedCareCharges)} " +
                                       "must present in the request with valid Id", HttpStatusCode.BadRequest);
            }

            // each requested care charge with non-empty Id should have matching DB record
            var unknownCareCharges = request.CareCharges
                .Where(requestedCharge =>
                    !requestedCharge.Id.IsEmpty() &&
                    !existingCareCharges.Any(existingCharge => existingCharge.Id == requestedCharge.Id))
                .Select(requestedCharge => requestedCharge.Id)
                .ToList();

            if (unknownCareCharges.Count > 0)
            {
                throw new ApiException($"Care charges {String.Join(", ", unknownCareCharges)} not found", HttpStatusCode.BadRequest);
            }

            // each care charge sub-type must have only one entry
            var duplicatedSubtypes = request.CareCharges
                .GroupBy(careCharge => careCharge.SubType)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key.GetDisplayName())
                .ToList();

            if (duplicatedSubtypes.Count > 0)
            {
                throw new ApiException("Not allowed to have more than one " +
                                       $"{String.Join(", ", duplicatedSubtypes)} in request", HttpStatusCode.BadRequest);
            }
        }

        private void ReplaceUpdatedCareCharges(CareChargesCreateDomain request, CarePackage package)
        {
            foreach (var requestedCharge in request.CareCharges)
            {
                // if existing charge date / cost / collector is changed, cancel it and create a new one instead.
                if (!requestedCharge.Id.IsEmpty())
                {
                    var existingCharge = package.Reclaims.Single(cc => cc.Id == requestedCharge.Id);

                    if (CareChargeHasChanged(existingCharge, requestedCharge) && requestedCharge.Status != ReclaimStatus.Cancelled)
                    {
                        existingCharge.Status = ReclaimStatus.Cancelled;
                        requestedCharge.Id = null;

                        package.Reclaims.Add(requestedCharge.ToEntity());
                    }
                    else
                    {
                        _mapper.Map(requestedCharge, existingCharge);
                    }
                }
                else
                {
                    package.Reclaims.Add(requestedCharge.ToEntity());
                }
            }
        }

        private static bool CareChargeHasChanged(CarePackageReclaim existingCareCharge, CareChargeReclaimCreationDomain newCareCharge)
        {
            return newCareCharge.StartDate.Date != existingCareCharge.StartDate.Date ||
                   newCareCharge.EndDate != existingCareCharge.EndDate ||
                   newCareCharge.Cost != existingCareCharge.Cost ||
                   newCareCharge.ClaimCollector != existingCareCharge.ClaimCollector;
        }

        private static string GetShortName(ReclaimSubType? subtype)
        {
            return subtype switch
            {
                ReclaimSubType.CareChargeProvisional => "Provisional",
                ReclaimSubType.CareCharge1To12Weeks => "1-12",
                ReclaimSubType.CareCharge13PlusWeeks => "13+",
                _ => String.Empty
            };
        }
    }
}
