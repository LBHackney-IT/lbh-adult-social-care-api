using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateFundedNursingCareUseCase : IUpdateFundedNursingCareUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IMapper _mapper;
        private readonly ICreatePackageResourceUseCase _createPackageResourceUseCase;

        public UpdateFundedNursingCareUseCase(ICarePackageGateway carePackageGateway,
            IDatabaseManager dbManager, IMapper mapper,
            ICreatePackageResourceUseCase createPackageResourceUseCase)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _mapper = mapper;
            _createPackageResourceUseCase = createPackageResourceUseCase;
        }

        public async Task UpdateAsync(CarePackageReclaimUpdateDomain requestedReclaim, Guid packageId)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Resources | PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            var reclaims = package.Reclaims
                .Where(reclaim =>
                    reclaim.Status != ReclaimStatus.Cancelled &&
                    reclaim.Type == ReclaimType.Fnc).ToList();

            var fncPayment = reclaims.SingleOrDefault(r => r.SubType is ReclaimSubType.FncPayment);
            var fncReclaim = reclaims.SingleOrDefault(r => r.SubType is ReclaimSubType.FncReclaim);


            if (fncPayment is null || fncReclaim is null)
            {
                throw new ApiException($"No FNC defined for package {packageId}", HttpStatusCode.NotFound);
            }

            if (requestedReclaim.HasAssessmentBeenCarried)
            {
                var fncReclaimId = fncReclaim.Id;

                _mapper.Map(requestedReclaim, fncPayment);
                _mapper.Map(requestedReclaim, fncReclaim);

                fncReclaim.Id = fncReclaimId;
                fncReclaim.Cost = Decimal.Negate(fncPayment.Cost);

                fncPayment.Subjective = SubjectiveConstants.FncPaymentSubjectiveCode;
                fncReclaim.Subjective = SubjectiveConstants.FncReclaimSubjectiveCode;

                ReclaimCostValidator.Validate(package);

                await using (var transaction = await _dbManager.BeginTransactionAsync())
                {
                    if (requestedReclaim.AssessmentFileId.IsEmpty() && requestedReclaim.AssessmentFile != null)
                    {
                        await _createPackageResourceUseCase.CreateFileAsync(
                            package.Id, PackageResourceType.FncAssessmentFile, requestedReclaim.AssessmentFile);
                    }

                    await _dbManager.SaveAsync();
                    await transaction.CommitAsync();
                }
            }
            else
            {
                fncPayment.Status = ReclaimStatus.Cancelled;
                fncReclaim.Status = ReclaimStatus.Cancelled;

                await _dbManager.SaveAsync();
            }
        }
    }
}
