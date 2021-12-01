using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateCarePackageReclaimUseCase : IUpdateCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;

        public UpdateCarePackageReclaimUseCase(
            ICarePackageReclaimGateway carePackageReclaimGateway, ICarePackageGateway carePackageGateway,
            IDatabaseManager dbManager, IMapper mapper,
            IFileStorage fileStorage)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public async Task UpdateAsync(CarePackageReclaimUpdateDomain carePackageReclaimUpdateDomain)
        {
            var carePackageReclaim = await _carePackageReclaimGateway.GetAsync(carePackageReclaimUpdateDomain.Id)
                .EnsureExistsAsync($"Care package reclaim with id {carePackageReclaimUpdateDomain.Id} not found");

            if (!carePackageReclaimUpdateDomain.HasAssessmentBeenCarried && carePackageReclaim.Type == ReclaimType.Fnc)
            {
                carePackageReclaim.Status = ReclaimStatus.Cancelled;
                await _dbManager.SaveAsync();
                return;
            }

            if (carePackageReclaimUpdateDomain?.AssessmentFileId == Guid.Empty)
            {
                var documentResponse = await _fileStorage.
                    SaveFileAsync(ConvertCarePlan(carePackageReclaimUpdateDomain.AssessmentFile), carePackageReclaimUpdateDomain.AssessmentFile?.FileName);
                carePackageReclaimUpdateDomain.AssessmentFileId = documentResponse?.FileId ?? Guid.Empty;
                carePackageReclaimUpdateDomain.AssessmentFileName = documentResponse?.FileName;
            }
            else
            {
                //todo FK: temp solution
                carePackageReclaimUpdateDomain.AssessmentFileName = carePackageReclaim.AssessmentFileName;
            }

            _mapper.Map(carePackageReclaimUpdateDomain, carePackageReclaim);
            await _dbManager.SaveAsync();
        }

        public async Task<IList<CarePackageReclaimDomain>> UpdateListAsync(CareChargeReclaimBulkUpdateDomain reclaimBulkUpdateDomain)
        {
            var requestedReclaimIds = reclaimBulkUpdateDomain.Reclaims.Select(r => r.Id).ToList();
            var existingReclaims = await _carePackageReclaimGateway.GetListAsync(requestedReclaimIds);

            EnsureReclaimsExist(requestedReclaimIds, existingReclaims);

            var package = await GetPackage(existingReclaims);
            var result = new List<CarePackageReclaim>();

            // Check overlap between existing and requested care charges
            ValidateUpdateCareCharges(existingReclaims, package);

            foreach (var existingReclaim in existingReclaims)
            {
                if (existingReclaim.Status.In(ReclaimStatus.Cancelled, ReclaimStatus.Ended))
                {
                    throw new ApiException($"Unable to edit reclaim in status {existingReclaim.Status}");
                }

                // For MVP scope always update provisional care charges and replace other types of care charges
                var requestedReclaim = reclaimBulkUpdateDomain.Reclaims.First(r => r.Id == existingReclaim.Id);

                if (existingReclaim.SubType is ReclaimSubType.CareChargeProvisional)
                {
                    UpdateProvisionalReclaim(requestedReclaim, existingReclaim, package);

                    if (reclaimBulkUpdateDomain?.AssessmentFileId == Guid.Empty)
                    {
                        var documentResponse = await _fileStorage.
                            SaveFileAsync(ConvertCarePlan(reclaimBulkUpdateDomain.AssessmentFile), reclaimBulkUpdateDomain.AssessmentFile?.FileName);
                        existingReclaim.AssessmentFileId = documentResponse?.FileId ?? Guid.Empty;
                        existingReclaim.AssessmentFileName = documentResponse?.FileName;
                    }
                    result.Add(existingReclaim);
                }
                else
                {
                    existingReclaim.Status = ReclaimStatus.Ended;
                    existingReclaim.EndDate = DateTimeOffset.Now.Date;

                    if (reclaimBulkUpdateDomain?.AssessmentFileId == Guid.Empty)
                    {
                        var documentResponse = await _fileStorage.SaveFileAsync(ConvertCarePlan(reclaimBulkUpdateDomain.AssessmentFile), reclaimBulkUpdateDomain.AssessmentFile?.FileName);
                        requestedReclaim.AssessmentFileId = documentResponse?.FileId ?? Guid.Empty;
                        requestedReclaim.AssessmentFileName = documentResponse?.FileName;
                    }

                    var newReclaim = CreateNewReclaim(requestedReclaim, existingReclaim, package);
                    result.Add(newReclaim);
                }

                package.Histories.Add(new CarePackageHistory
                {
                    Description = $"{existingReclaim.Type.GetDisplayName()} {existingReclaim.SubType.GetDisplayName()} Updated",
                });
            }

            // Change package status to in progress
            package.Status = PackageStatus.InProgress;

            await _dbManager.SaveAsync();
            return result.ToDomain().ToList();
        }

        private static void EnsureReclaimsExist(IEnumerable<Guid> reclaimIds, IEnumerable<CarePackageReclaim> existingReclaims)
        {
            var missedIds = reclaimIds
                .Where(id => !existingReclaims.Any(reclaim => reclaim.Id == id))
                .ToList();

            if (missedIds.Any())
            {
                throw new ApiException($"Care package reclaims {String.Join(", ", missedIds)} not found", HttpStatusCode.NotFound);
            }
        }

        private async Task<CarePackage> GetPackage(IEnumerable<CarePackageReclaim> existingReclaims)
        {
            var packageIds = existingReclaims
                .Select(reclaim => reclaim.CarePackageId)
                .Distinct().ToList();

            if (packageIds.Count != 1)
            {
                throw new ApiException("Reclaims from different care packages cannot be mixed in single request", HttpStatusCode.BadRequest);
            }

            var packageId = packageIds.First();
            return await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Details, true)
                .EnsureExistsAsync($"Care package {packageId} not found");
        }

        private void UpdateProvisionalReclaim(CarePackageReclaimUpdateDomain requestedReclaim, CarePackageReclaim existingReclaim, CarePackage package)
        {
            _mapper.Map(requestedReclaim, existingReclaim);

            // empty start date may come from package builder
            var coreCost = package.Details.FirstOrDefault(d => d.Type is PackageDetailType.CoreCost);
            if (coreCost != null)
            {
                existingReclaim.StartDate = coreCost.StartDate;
            }
        }

        private static CarePackageReclaim CreateNewReclaim(CarePackageReclaimUpdateDomain requestedReclaim, CarePackageReclaim existingReclaim, CarePackage package)
        {
            var newReclaim = requestedReclaim.ToEntity();

            newReclaim.Id = Guid.Empty;
            newReclaim.Type = existingReclaim.Type;
            newReclaim.SubType = existingReclaim.SubType;

            package.Reclaims.Add(newReclaim);
            return newReclaim;
        }

        private static void ValidateUpdateCareCharges(List<CarePackageReclaim> existingReclaims, CarePackage carePackage)
        {
            var existingProvisionalCareCharge = GetCarePackageReclaim(existingReclaims, carePackage, ReclaimSubType.CareChargeProvisional);
            var secondCareChargeSubType = GetCarePackageReclaim(existingReclaims, carePackage, CareChargeSubTypes.GetCareChargeSubTypeOrder(ReclaimSubType.CareChargeProvisional));

            if (existingProvisionalCareCharge != null)
            {
                if (secondCareChargeSubType != null)
                {
                    if (existingProvisionalCareCharge.EndDate != secondCareChargeSubType.StartDate.AddDays(-1))
                    {
                        throw new ApiException(
                            $"{secondCareChargeSubType.SubType} start date is invalid. Date for {secondCareChargeSubType.SubType} should be consecutive with previous care charge type",
                            HttpStatusCode.BadRequest);
                    }
                }
            }

            if (secondCareChargeSubType != null)
            {
                var thirdCareChargeSubType = GetCarePackageReclaim(existingReclaims, carePackage,
                    CareChargeSubTypes.GetCareChargeSubTypeOrder(secondCareChargeSubType.SubType));

                if (thirdCareChargeSubType != null)
                {
                    if (secondCareChargeSubType.EndDate != thirdCareChargeSubType.StartDate.AddDays(-1))
                    {
                        throw new ApiException(
                            $"{thirdCareChargeSubType.SubType} start date is invalid. Date for {thirdCareChargeSubType.SubType} should be consecutive with previous care charge type",
                            HttpStatusCode.BadRequest);
                    }
                }
            }
        }

        private static CarePackageReclaim GetCarePackageReclaim(List<CarePackageReclaim> carePackageReclaim, CarePackage carePackage,
            ReclaimSubType reclaimSubType)
        {
            var existingCareCharge = carePackageReclaim.FirstOrDefault(r => r.SubType == reclaimSubType) ?? carePackage.Reclaims.FirstOrDefault(r => r.SubType == reclaimSubType);

            return existingCareCharge;
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
