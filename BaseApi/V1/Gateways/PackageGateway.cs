using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure;
using BaseApi.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways
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
            Package packageToUpdate = await _databaseContext.Packages.FirstOrDefaultAsync(item => item.PackageName == package.PackageName).ConfigureAwait(false);
            packageToUpdate = new Package();
            if (packageToUpdate == null)
            {
                await _databaseContext.Packages.AddAsync(packageToUpdate).ConfigureAwait(false);
                packageToUpdate.PackageName = package.PackageName;
                packageToUpdate.CreatorId = package.CreatorId;
                packageToUpdate.DateCreated = package.DateCreated;
                packageToUpdate.UpdatorId = package.UpdatorId;
                packageToUpdate.DateUpdated = package.DateUpdated;
                packageToUpdate.Success = true;
            }
            else
            {
                packageToUpdate.Message = $"This record already exist Package Name: {package.PackageName}";
                packageToUpdate.Success = false;
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return packageToUpdate;
        }

        public async Task<Package> GetAsync(Guid packageId)
        {
            return await _databaseContext.Packages.FirstOrDefaultAsync(item => item.Id == packageId).ConfigureAwait(false);
        }
        public async Task<IList<Package>> ListAsync()
        {
            return await _databaseContext.GetPackagesAsync().ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(Guid packageId)
        {
            var result = _databaseContext.Packages.Remove(new Package() { Id = packageId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }
    }
}
