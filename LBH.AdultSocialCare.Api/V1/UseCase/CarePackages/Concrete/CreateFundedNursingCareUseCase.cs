using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateFundedNursingCareUseCase : ICreateFundedNursingCareUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly ICreatePackageResourceUseCase _createPackageResourceUseCase;

        public CreateFundedNursingCareUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager,
            ICreatePackageResourceUseCase createPackageResourceUseCase)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _createPackageResourceUseCase = createPackageResourceUseCase;
        }

        public async Task<CarePackageReclaimResponse> ExecuteAsync(CarePackageReclaimCreationDomain requestedReclaim)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(requestedReclaim.CarePackageId, PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package {requestedReclaim.CarePackageId} not found");

            ValidateReclaim(requestedReclaim, package);

            // two FNC items are created
            // - one for the real payment to home, which will be included in Core Cost
            // - another one is for reclaim, with negative amount, which will compensate payment item.
            // Just item with FNCPayment sub-type is used in UI / brokerage, reclaim item is for invoicing
            var fncPayment = CreateReclaimEntity(requestedReclaim, ReclaimSubType.FncPayment);
            var fncReclaim = CreateReclaimEntity(requestedReclaim, ReclaimSubType.FncReclaim);

            fncReclaim.Cost = Decimal.Negate(requestedReclaim.Cost);

            package.Reclaims.Add(fncPayment);
            package.Reclaims.Add(fncReclaim);

            package.Histories.Add(new CarePackageHistory { Description = "FNC Created" });

            if (package.Status is PackageStatus.Approved)
            {
                package.Status = PackageStatus.SubmittedForApproval;
            }

            ReclaimCostValidator.Validate(package);

            await using (var transaction = await _dbManager.BeginTransactionAsync())
            {
                await _createPackageResourceUseCase.CreateFileAsync(
                    package.Id, PackageResourceType.FncAssessmentFile, requestedReclaim.AssessmentFile);
                await _dbManager.SaveAsync("Could not save FNC reclaim to database");

                await transaction.CommitAsync();
            }

            return fncPayment.ToDomain().ToResponse();
        }

        private static void ValidateReclaim(CarePackageReclaimCreationDomain requestedReclaim, CarePackage package)
        {
            var coreCost = package.Details
                .FirstOrDefault(d => d.Type is PackageDetailType.CoreCost)
                .EnsureExists($"Core cost for package {package.Id} not found", HttpStatusCode.InternalServerError);

            if (package.Status.In(PackageStatus.Cancelled, PackageStatus.Ended))
            {
                throw new ApiException($"Can not create FNC reclaim for care package status {package.Status.GetDisplayName()}", HttpStatusCode.BadRequest);
            }

            if (package.PackageType != PackageType.NursingCare)
            {
                throw new ApiException($"FNC only allowed for nursing care package. Package {package.Id} is invalid", HttpStatusCode.BadRequest);
            }

            if (package.Reclaims.Any(r => r.Type is ReclaimType.Fnc))
            {
                throw new ApiException($"FNC already added to package {package.Id}", HttpStatusCode.Conflict);
            }

            if (!requestedReclaim.StartDate.IsInRange(coreCost.StartDate, coreCost.EndDate ?? DateTimeOffset.UtcNow.AddYears(10)))
            {
                throw new ApiException($"FNC start date must be equal or greater than {coreCost.StartDate}", HttpStatusCode.UnprocessableEntity);
            }

            if (requestedReclaim.EndDate != null)
            {
                var fncEndDate = (DateTimeOffset) requestedReclaim.EndDate;
                if (coreCost.EndDate != null && !fncEndDate.IsInRange(coreCost.StartDate, (DateTimeOffset) coreCost.EndDate))
                {
                    throw new ApiException($"FNC end date is invalid. Must be in the range {coreCost.StartDate} - {coreCost.EndDate}", HttpStatusCode.UnprocessableEntity);
                }
            }
        }

        private static CarePackageReclaim CreateReclaimEntity(CarePackageReclaimCreationDomain requestedReclaim, ReclaimSubType subType)
        {
            var fncPayment = requestedReclaim.ToEntity();

            fncPayment.Type = ReclaimType.Fnc;
            fncPayment.SubType = subType;
            fncPayment.Status = ReclaimStatus.Active;
            fncPayment.Subjective = fncPayment.SubType == ReclaimSubType.FncPayment ? SubjectiveConstants.FncPaymentSubjectiveCode : SubjectiveConstants.FncReclaimSubjectiveCode;

            return fncPayment;
        }
    }
}
