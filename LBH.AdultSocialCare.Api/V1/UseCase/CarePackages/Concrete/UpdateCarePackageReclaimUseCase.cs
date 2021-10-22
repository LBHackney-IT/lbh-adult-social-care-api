using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateCarePackageReclaimUseCase : IUpdateCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public UpdateCarePackageReclaimUseCase(
            ICarePackageReclaimGateway carePackageReclaimGateway,
            ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task UpdateAsync(CarePackageReclaimUpdateDomain carePackageReclaimUpdateDomain)
        {
            await _carePackageReclaimGateway.UpdateAsync(carePackageReclaimUpdateDomain);
        }

        public async Task<IList<CarePackageReclaimDomain>> UpdateListAsync(IList<CarePackageReclaimUpdateDomain> requestedReclaims)
        {
            var requestedReclaimIds = requestedReclaims.Select(r => r.Id).ToList();
            var existingReclaims = await _carePackageReclaimGateway.GetListAsync(requestedReclaimIds);

            EnsureReclaimsExist(requestedReclaimIds, existingReclaims);

            var packageId = GetPackageId(existingReclaims);
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.None, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            var newReclaims = requestedReclaims.ToEntity().ToList();
            foreach (var newReclaim in newReclaims)
            {
                newReclaim.Type = existingReclaims.First(r => r.Id == newReclaim.Id).Type;
                newReclaim.Id = Guid.Empty;
            }

            // End existing reclaims and replace them with new ones
            existingReclaims.ForEach(r => r.Status = ReclaimStatus.Ended);
            package.Reclaims.AddRange(newReclaims);

            await _dbManager.SaveAsync();
            return newReclaims.ToDomain().ToList();
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

        private static Guid GetPackageId(IEnumerable<CarePackageReclaim> existingReclaims)
        {
            var packageIds = existingReclaims
                .Select(reclaim => reclaim.CarePackageId)
                .Distinct().ToList();

            if (packageIds.Count != 1)
            {
                throw new ApiException("Reclaims from different care packages cannot be mixed in single request", HttpStatusCode.BadRequest);
            }

            return packageIds.First();
        }
    }
}
