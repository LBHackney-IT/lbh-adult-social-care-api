using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{

    public class PackageGateway : IPackageGateway
    {

        private readonly DatabaseContext _databaseContext;

        public PackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Package> UpsertAsync(Package package)
        {
            Package packageToUpdate = await _databaseContext.Packages
                .FirstOrDefaultAsync(item => item.PackageType == package.PackageType)
                .ConfigureAwait(false);

            if (packageToUpdate == null)
            {
                packageToUpdate = new Package();
                await _databaseContext.Packages.AddAsync(packageToUpdate).ConfigureAwait(false);
                packageToUpdate.PackageType = package.PackageType;
                packageToUpdate.CreatorId = package.CreatorId;
                packageToUpdate.UpdatorId = package.UpdatorId;
                packageToUpdate.DateUpdated = package.DateUpdated;
            }
            else
            {
                throw new ErrorException($"This record already exist Package Name: {package.PackageType}");
            }

            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

            return packageToUpdate;
        }

        public async Task<Package> GetAsync(int packageId)
        {
            return await _databaseContext.Packages.FirstOrDefaultAsync(item => item.Id == packageId)
                .ConfigureAwait(false);
        }

        public async Task<IList<Package>> ListAsync()
        {
            return await _databaseContext.Packages.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(int packageId)
        {
            _databaseContext.Packages.Remove(new Package
            {
                Id = packageId
            });

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }

    }

}
