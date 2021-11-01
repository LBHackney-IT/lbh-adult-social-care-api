using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
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
            var result = _databaseContext.PackageStatuses.Remove(new PackageStatusOption
            { Id = statusId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<PackageStatusOption> GetAsync(int statusId)
        {
            return await _databaseContext.PackageStatuses.FirstOrDefaultAsync(item => item.Id == statusId).ConfigureAwait(false);
        }

        public async Task<IList<PackageStatusOption>> ListAsync()
        {
            return await _databaseContext.PackageStatuses.ToListAsync().ConfigureAwait(false);
        }

        public async Task<PackageStatusOption> UpsertAsync(PackageStatusOption statusOption)
        {
            PackageStatusOption statusOptionToUpdate = await _databaseContext.PackageStatuses.FirstOrDefaultAsync(item => item.StatusName == statusOption.StatusName).ConfigureAwait(false);
            if (statusOptionToUpdate == null)
            {
                statusOptionToUpdate = new PackageStatusOption();
                await _databaseContext.PackageStatuses.AddAsync(statusOptionToUpdate).ConfigureAwait(false);
                statusOptionToUpdate.StatusName = statusOption.StatusName;
            }
            else
            {
                throw new ApiException($"This record already exist PackageStatuses Name: {statusOption.StatusName}");
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return statusOptionToUpdate;
        }
    }
}
