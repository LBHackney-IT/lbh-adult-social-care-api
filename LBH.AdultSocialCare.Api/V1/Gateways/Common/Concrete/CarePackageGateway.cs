using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageGateway : ICarePackageGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarePackage> GetPackageAsync(Guid packageId)
        {
            return await _dbContext.CarePackages
                .Where(p => p.Id == packageId)
                .Include(p => p.Details)
                .FirstOrDefaultAsync();
        }

        public async Task<CarePackage> CheckPackageExistsAsync(Guid packageId, bool trackChanges)
        {
            var carePackage = await _dbContext.CarePackages.Where(cp => cp.Id.Equals(packageId)).TrackChanges(trackChanges).SingleOrDefaultAsync();

            if (carePackage == null)
            {
                throw new ApiException($"Care package with id {packageId} not found");
            }

            return carePackage;
        }

        public void Create(CarePackage newCarePackage)
        {
            _dbContext.CarePackages.Add(newCarePackage);
        }
    }
}
