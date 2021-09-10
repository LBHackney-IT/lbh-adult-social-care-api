using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class PackageCareChargeGateway : IPackageCareChargeGateway
    {
        private readonly DatabaseContext _dbContext;

        public PackageCareChargeGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PackageCareChargePlainDomain> CreateAsync(PackageCareCharge newPackageCareCharge)
        {
            var entry = await _dbContext.PackageCareCharges.AddAsync(newPackageCareCharge).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.ToPlainDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Failed to create package care charge {ex.Message}", ex);
            }
        }

        public async Task<PackageCareChargePlainDomain> CheckIfExistsAsync(Guid packageCareChargeId)
        {
            var careCharge = await _dbContext.PackageCareCharges.Where(pcc => pcc.Id.Equals(packageCareChargeId))
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (careCharge == null)
            {
                throw new ApiException($"Package care charge with id {packageCareChargeId} not found",
                    StatusCodes.Status404NotFound);
            }

            return careCharge.ToPlainDomain();
        }
    }
}
