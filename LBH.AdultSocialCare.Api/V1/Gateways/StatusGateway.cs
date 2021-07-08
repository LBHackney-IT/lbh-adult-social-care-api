using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class StatusGateway : IStatusGateway
    {
        private readonly DatabaseContext _databaseContext;

        public StatusGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(int statusId)
        {
            var result = _databaseContext.PackageStatuses.Remove(new PackageStatus
            { Id = statusId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<PackageStatus> GetAsync(int statusId)
        {
            return await _databaseContext.PackageStatuses.FirstOrDefaultAsync(item => item.Id == statusId).ConfigureAwait(false);
        }

        public async Task<IList<PackageStatus>> ListAsync()
        {
            return await _databaseContext.PackageStatuses.ToListAsync().ConfigureAwait(false);
        }

        public async Task<PackageStatus> UpsertAsync(PackageStatus status)
        {
            PackageStatus statusToUpdate = await _databaseContext.PackageStatuses.FirstOrDefaultAsync(item => item.StatusName == status.StatusName).ConfigureAwait(false);
            if (statusToUpdate == null)
            {
                statusToUpdate = new PackageStatus();
                await _databaseContext.PackageStatuses.AddAsync(statusToUpdate).ConfigureAwait(false);
                statusToUpdate.StatusName = status.StatusName;
                statusToUpdate.CreatorId = status.CreatorId;
                statusToUpdate.UpdaterId = status.UpdaterId;
                statusToUpdate.DateUpdated = status.DateUpdated;
            }
            else
            {
                throw new ApiException($"This record already exist PackageStatuses Name: {status.StatusName}");
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return statusToUpdate;
        }
    }
}
