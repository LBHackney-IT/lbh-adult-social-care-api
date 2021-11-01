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
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateCarePackageReclaimUseCase : ICreateCarePackageReclaimUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IMapper _mapper;

        public CreateCarePackageReclaimUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager, IMapper mapper)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _mapper = mapper;
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

            if (newReclaim is null)
            {
                newReclaim = reclaimCreationDomain.ToEntity();
                newReclaim.Type = reclaimType;

                carePackage.Reclaims.Add(newReclaim);
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
                if (provisionalReclaim != null)
                {
                    provisionalReclaim.Status = ReclaimStatus.Ended;
                    provisionalReclaim.EndDate = DateTimeOffset.Now.Date;
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
    }
}
