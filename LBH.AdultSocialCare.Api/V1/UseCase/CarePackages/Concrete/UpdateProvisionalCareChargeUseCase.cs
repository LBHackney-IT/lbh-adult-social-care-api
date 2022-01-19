using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
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
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateProvisionalCareChargeUseCase : IUpdateProvisionalCareChargeUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IMapper _mapper;

        public UpdateProvisionalCareChargeUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager, IMapper mapper)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _mapper = mapper;
        }

        public async Task UpdateAsync(Guid packageId, CarePackageReclaimUpdateDomain requestedReclaim)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Resources | PackageFields.Reclaims, true)
                .EnsureExists($"Care Package {packageId} not found");

            var existingReclaim = package.Reclaims
                .SingleOrDefault(r => r.Id == requestedReclaim.Id)
                .EnsureExists($"Care package reclaim {requestedReclaim.Id} not found");

            ValidateRequest(existingReclaim, package);

            if (ShouldReplaceReclaim(existingReclaim, requestedReclaim))
            {
                existingReclaim.Status = ReclaimStatus.Cancelled;
                requestedReclaim.Id = Guid.Empty;

                package.Reclaims.Add(requestedReclaim.ToEntity());
            }
            else
            {
                _mapper.Map(requestedReclaim, existingReclaim);
            }

            ReclaimCostValidator.Validate(package);

            await _dbManager.SaveAsync("Could not update care package reclaim");
        }

        private static void ValidateRequest(CarePackageReclaim existingReclaim, CarePackage package)
        {
            if (existingReclaim.SubType != ReclaimSubType.CareChargeProvisional)
            {
                throw new ApiException("Only provisional care charges supported", HttpStatusCode.BadRequest);
            }

            var packageAssessed = package.Reclaims.Any(
                r => r.Type == ReclaimType.CareCharge &&
                     r.SubType != ReclaimSubType.CareChargeProvisional &&
                     r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending, ReclaimStatus.Ended));

            if (packageAssessed)
            {
                throw new ApiException("Operation not allowed. Package has been assessed.", HttpStatusCode.BadRequest);
            }
        }

        private static bool ShouldReplaceReclaim(CarePackageReclaim existingReclaim, CarePackageReclaimUpdateDomain requestedReclaim)
        {
            return existingReclaim.StartDate != requestedReclaim.StartDate ||
                   existingReclaim.EndDate != requestedReclaim.EndDate ||
                   existingReclaim.Cost != requestedReclaim.Cost ||
                   existingReclaim.ClaimCollector != requestedReclaim.ClaimCollector;
        }
    }
}
