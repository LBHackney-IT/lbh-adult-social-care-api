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
    public class StatusGateway : IStatusGateway
    {
        private readonly DatabaseContext _databaseContext;

        public StatusGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid statusId)
        {
            var result = _databaseContext.Status.Remove(new Status() { Id = statusId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<Status> GetAsync(Guid statusId)
        {
            return await _databaseContext.Status.FirstOrDefaultAsync(item => item.Id == statusId).ConfigureAwait(false);
        }

        public async Task<IList<Status>> ListAsync()
        {
            return await _databaseContext.GetStatusAsync().ConfigureAwait(false);
        }

        public async Task<Status> UpsertAsync(Status status)
        {
            Status statusToUpdate = await _databaseContext.Status.FirstOrDefaultAsync(item => item.StatusName == status.StatusName).ConfigureAwait(false);
            if (statusToUpdate == null)
            {
                statusToUpdate = new Status();
                await _databaseContext.Status.AddAsync(statusToUpdate).ConfigureAwait(false);
                statusToUpdate.StatusName = status.StatusName;
                statusToUpdate.CreatorId = status.CreatorId;
                statusToUpdate.DateCreated = status.DateCreated;
                statusToUpdate.UpdatorId = status.UpdatorId;
                statusToUpdate.DateUpdated = status.DateUpdated;
            }
            else
            {
                throw new ErrorException($"This record already exist Status Name: {status.StatusName}");
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return statusToUpdate;
        }
    }
}
