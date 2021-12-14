using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpsertCareChargesUseCase : IUpsertCareChargesUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IFileStorage _fileStorage;
        private readonly IMapper _mapper;
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;

        public UpsertCareChargesUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager, IFileStorage fileStorage, IMapper mapper, ICarePackageReclaimGateway carePackageReclaimGateway)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _fileStorage = fileStorage;
            _mapper = mapper;
            _carePackageReclaimGateway = carePackageReclaimGateway;
        }

        public async Task ExecuteAsync(Guid carePackageId, CareChargesCreateDomain careChargesCreateDomain)
        {
            // await using var transaction = await _dbManager.BeginTransactionAsync();
            // All care charges to have one care package Id
            foreach (var careCharge in careChargesCreateDomain.CareCharges)
            {
                careCharge.CarePackageId = carePackageId;
            }

            ValidateCareChargeModificationRequest(careChargesCreateDomain.CareCharges);

            // Get package with all reclaims
            var package = await _carePackageGateway.GetPackageAsync(carePackageId, PackageFields.Settings | PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package with id {carePackageId} not found");

            // Is user in Section 117, reject care charges
            if (package.Settings.IsS117Client)
            {
                throw new ApiException($"This service user is under S117, not allowed to add care charges", HttpStatusCode.BadRequest);
            }

            var validReclaimStatuses = new[] { ReclaimStatus.Active, ReclaimStatus.Ended, ReclaimStatus.Pending };
            var existingCareCharges = package.Reclaims
                .Where(r => r.Type == ReclaimType.CareCharge && validReclaimStatuses.Contains(r.Status)).ToList();

            EnsureUpdatedReclaimsExist(careChargesCreateDomain.CareCharges, existingCareCharges);

            ValidateBeforeCreate(package, careChargesCreateDomain.CareCharges, existingCareCharges);

            // Declare values
            var provisionalCareCharge = careChargesCreateDomain.CareCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeProvisional);
            var oneToTwelveCareCharge = careChargesCreateDomain.CareCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks);
            var thirteenPlusCareCharge = careChargesCreateDomain.CareCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

            var existingProvisionalCareCharge = existingCareCharges.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeProvisional);
            var existingOneToTwelveCareCharge = existingCareCharges.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks);
            var existingThirteenPlusCareCharge = existingCareCharges.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

            // 13+ and package has end date, set end date on 13+
            var coreCost = package.Details.SingleOrDefault(d => d.Type == PackageDetailType.CoreCost);
            if (thirteenPlusCareCharge is { EndDate: null } && coreCost?.EndDate != null)
            {
                thirteenPlusCareCharge.EndDate = coreCost.EndDate;
            }

            // If not in Db add
            if (existingProvisionalCareCharge == null && provisionalCareCharge != null)
            {
                package.Reclaims.Add(provisionalCareCharge.ToEntity());
            }
            if (existingOneToTwelveCareCharge == null && oneToTwelveCareCharge != null)
            {
                package.Reclaims.Add(oneToTwelveCareCharge.ToEntity());
            }
            if (existingThirteenPlusCareCharge == null && thirteenPlusCareCharge != null)
            {
                package.Reclaims.Add(thirteenPlusCareCharge.ToEntity());
            }

            // If dates have changed, update care charge
            foreach (var existingCareCharge in existingCareCharges)
            {
                if (existingCareCharge.SubType == ReclaimSubType.CareChargeProvisional && provisionalCareCharge != null)
                {
                    _mapper.Map(provisionalCareCharge, existingCareCharge);
                    if (oneToTwelveCareCharge != null && existingCareCharge.StartDate == oneToTwelveCareCharge.StartDate)
                    {
                        existingCareCharge.Status = ReclaimStatus.Cancelled;
                    }
                }

                if (existingCareCharge.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks && oneToTwelveCareCharge != null)
                {
                    _mapper.Map(oneToTwelveCareCharge, existingCareCharge);
                }

                if (existingCareCharge.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks && thirteenPlusCareCharge != null)
                {
                    _mapper.Map(thirteenPlusCareCharge, existingCareCharge);
                }
            }

            try
            {
                EnsureValidPackageTotals(package);
                await _dbManager.SaveAsync();
            }
            catch (ApiException ex)
            {
                throw new ApiException(ex.Message, ex.StatusCode);
            }

            // Get package and check reclaim totals are valid
            /*var packageFromDb = await _carePackageGateway.GetPackageAsync(carePackageId, PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package with id {carePackageId} not found");*/
        }

        private static void EnsureValidPackageTotals(CarePackage package)
        {
            var coreCost = package.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package {package.Id} not found");

            var additionalNeeds = package.Details
                .Where(d => d.Type == PackageDetailType.AdditionalNeed).ToList();

            CareChargeExtensions.NegateNetOffCosts(package);

            var summary = new CarePackageSummaryDomain
            {
                StartDate = coreCost.StartDate,
                EndDate = coreCost.EndDate,
                CostOfPlacement = coreCost.Cost,

                AdditionalWeeklyNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.Weekly).ToDomain(),
                AdditionalOneOffNeeds = additionalNeeds.Where(d => d.CostPeriod is PaymentPeriod.OneOff).ToDomain(),

                CareCharges = package.Reclaims.Where(r => r.Type is ReclaimType.CareCharge).ToDomain(),
                FundedNursingCare = package.Reclaims.FirstOrDefault(r => r.Type is ReclaimType.Fnc)?.ToDomain()
            };

            var validReclaimStatuses = new[] { ReclaimStatus.Active, ReclaimStatus.Ended, ReclaimStatus.Pending };
            var startDates = new List<DateTimeOffset> { coreCost.StartDate };
            startDates.AddRange(summary.CareCharges.Where(cc => cc.Status.In(validReclaimStatuses)).Select(careCharge => careCharge.StartDate).ToList());
            startDates = startDates.Distinct().ToList();

            foreach (var startDate in startDates)
            {
                CareChargeExtensions.CalculateReclaimSubTotals(package, summary, coreCost, startDate.Date, validReclaimStatuses);
                CareChargeExtensions.CalculateTotals(summary, coreCost, startDate.Date);

                var reclaimsTotal = Math.Abs(summary.SupplierReclaims?.SubTotal ?? 0) + Math.Abs(summary.HackneyReclaims?.SubTotal ?? 0);
                var packageSubTotal = summary.SubTotalCost;

                if (reclaimsTotal > packageSubTotal)
                {
                    throw new ApiException(
                        $"Not allowed. Reclaim total {decimal.Round(reclaimsTotal, 2)} at date {startDate.Date: yyyy-MM-dd} is greater that package cost of {decimal.Round(packageSubTotal, 2)}",
                        HttpStatusCode.BadRequest);
                }
            }
        }

        private static void ValidateCareChargeModificationRequest(IList<CareChargeReclaimCreationDomain> careCharges)
        {
            // In request each care charge sub-type can have only one entry
            var invalidSubType = (from c in careCharges
                                  group c by c.SubType
                into grp
                                  where grp.Count() > 1
                                  select grp.Key).ToList();

            if (invalidSubType.Any())
            {
                throw new ApiException($"Not allowed to have more than one {invalidSubType.First().GetDisplayName()} in request", HttpStatusCode.BadRequest);
            }

            var provisionalCareCharge = careCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeProvisional);
            var oneToTwelveCareCharge = careCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks);
            var thirteenPlusCareCharge = careCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

            //If package has care charge other than provisional, provisional must have end date
            if ((oneToTwelveCareCharge != null || thirteenPlusCareCharge != null) && provisionalCareCharge?.EndDate == null)
            {
                throw new ApiException($"Provisional care charge must have an end date", HttpStatusCode.BadRequest);
            }

            // 1-12 must have end date
            if (oneToTwelveCareCharge is { EndDate: null })
            {
                throw new ApiException($"1-12 care charge must have an end date", HttpStatusCode.BadRequest);
            }

            //No gaps in care charge date allowed
            if (provisionalCareCharge != null && oneToTwelveCareCharge != null)
            {
                // 1-12 weeks starts a day after provisional if not on package start date which will cancel provisional care charge
                if ((provisionalCareCharge.StartDate.Date != oneToTwelveCareCharge.StartDate.Date) && (provisionalCareCharge.EndDate.GetValueOrDefault().Date.AddDays(1) !=
                    oneToTwelveCareCharge.StartDate.Date))
                {
                    throw new ApiException($"1-12 must start one day after provisional care charge end", HttpStatusCode.BadRequest);
                }
            }

            // Package cannot have 13+ without 1-12
            if (thirteenPlusCareCharge != null && oneToTwelveCareCharge == null)
            {
                throw new ApiException($"Not allowed to have care charges for 13+ without 1-12", HttpStatusCode.BadRequest);
            }

            if (oneToTwelveCareCharge != null && thirteenPlusCareCharge != null)
            {
                // 13+ starts a day after 1-12
                if (oneToTwelveCareCharge.EndDate.GetValueOrDefault().Date.AddDays(1) != thirteenPlusCareCharge.StartDate.Date)
                {
                    var expectedStart = oneToTwelveCareCharge.EndDate.GetValueOrDefault().Date.AddDays(1);
                    throw new ApiException($"13+ must start one day after 1-12 end: {expectedStart:yyy-MM-dd}", HttpStatusCode.BadRequest);
                }
            }
        }

        private static void EnsureUpdatedReclaimsExist(IEnumerable<CareChargeReclaimCreationDomain> modifiedReclaims, IEnumerable<CarePackageReclaim> existingReclaims)
        {
            var modifiedReclaimIds = modifiedReclaims.Where(cc => cc.Id != null).Select(cc => (Guid) cc.Id);
            var existingReclaimIds = existingReclaims.Where(r => r.Type == ReclaimType.CareCharge).Select(r => r.Id)
                .ToList();
            var missedIds = modifiedReclaimIds
                .Where(id => !existingReclaimIds.Contains(id))
                .ToList();

            if (missedIds.Any())
            {
                throw new ApiException($"Care package reclaims {String.Join(", ", missedIds)} not found", HttpStatusCode.NotFound);
            }
        }

        private static void ValidateBeforeCreate(CarePackage package,
            IList<CareChargeReclaimCreationDomain> modifiedCareCharges, IList<CarePackageReclaim> existingReclaims)
        {
            // Get package core cost
            var coreCost = package.Details.SingleOrDefault(d => d.Type == PackageDetailType.CoreCost);
            if (coreCost == null)
            {
                throw new ApiException($"Not allowed to add care charges. Package core cost must be added first",
                    HttpStatusCode.BadRequest);
            }

            var provisionalCareCharge = modifiedCareCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeProvisional);
            var oneToTwelveCareCharge = modifiedCareCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks);
            var thirteenPlusCareCharge = modifiedCareCharges.SingleOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

            var existingProvisionalCareCharge = existingReclaims.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeProvisional);
            var existingOneToTwelveCareCharge = existingReclaims.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks);
            var existingThirteenPlusCareCharge = existingReclaims.FirstOrDefault(cc => cc.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

            var minCareChargeStartDate = Dates.Min(provisionalCareCharge?.StartDate, oneToTwelveCareCharge?.StartDate,
                thirteenPlusCareCharge?.StartDate);

            // Care charges cannot be before package start date
            if (minCareChargeStartDate.Date < coreCost.StartDate.Date)
            {
                throw new ApiException($"Care charge start date cannot be before package start date. Expected min start date {coreCost.StartDate.Date:yyyy-MM-dd}",
                    HttpStatusCode.BadRequest);
            }

            // Initial care charge must start on package start date
            if (minCareChargeStartDate.Date != coreCost.StartDate.Date)
            {
                throw new ApiException($"Initial care charge must start on package start date",
                    HttpStatusCode.BadRequest);
            }

            // Only provisional care charge, ongoing and package has end date, make package end date to be end date of provisional care charge
            if (provisionalCareCharge is { EndDate: null } && oneToTwelveCareCharge == null && thirteenPlusCareCharge == null && coreCost.EndDate != null)
            {
                provisionalCareCharge.EndDate = coreCost.EndDate;
            }

            // Existing reclaim should not miss on update
            if ((provisionalCareCharge == null && existingProvisionalCareCharge != null) || (existingProvisionalCareCharge != null && provisionalCareCharge?.Id != existingProvisionalCareCharge?.Id))
            {
                throw new ApiException($"Provisional care charge must be in request and with a valid Id", HttpStatusCode.BadRequest);
            }

            if ((oneToTwelveCareCharge == null && existingOneToTwelveCareCharge != null) || (existingOneToTwelveCareCharge != null && oneToTwelveCareCharge?.Id != existingOneToTwelveCareCharge?.Id))
            {
                throw new ApiException($"1-12 care charge must be in request and with a valid Id", HttpStatusCode.BadRequest);
            }

            if ((thirteenPlusCareCharge == null && existingThirteenPlusCareCharge != null) || (existingThirteenPlusCareCharge != null && thirteenPlusCareCharge?.Id != existingThirteenPlusCareCharge?.Id))
            {
                throw new ApiException($"13+ care charge must be in request and with a valid Id", HttpStatusCode.BadRequest);
            }

            // If package core cost ongoing or package end date greater than/= 1-12 end date, 1-12 must be exactly 12 weeks
            if (oneToTwelveCareCharge != null && (coreCost.EndDate == null || coreCost.EndDate.GetValueOrDefault().Date >= oneToTwelveCareCharge.StartDate.Date.AddDays(84)))
            {
                if ((oneToTwelveCareCharge.EndDate.GetValueOrDefault().Date - oneToTwelveCareCharge.StartDate.Date).Days != 84)
                {
                    var expectedEndDate = oneToTwelveCareCharge.StartDate.Date.AddDays(84);
                    throw new ApiException($"1-12 must take exactly 12 weeks: Expected end date is {expectedEndDate:yyyy-MM-dd}", HttpStatusCode.BadRequest);
                }
            }

            // If package core cost has end date, care charge end date cannot be after that date
            if (coreCost.EndDate != null)
            {
                var maxCareChargeEndDate = Dates.Max(provisionalCareCharge?.EndDate, oneToTwelveCareCharge?.EndDate,
                    thirteenPlusCareCharge?.EndDate);

                if (maxCareChargeEndDate.Date > coreCost.EndDate.GetValueOrDefault().Date)
                {
                    throw new ApiException(
                        $"Max care charge end date expected to be {coreCost.EndDate.GetValueOrDefault().Date:yyyy-MM-dd}", HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
