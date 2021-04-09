using BaseApi.V1.Domain;
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
    public class HomeCarePackageGateway : IHomeCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public HomeCarePackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<HomeCarePackage> GetAsync(Guid homeCarePackageId)
        {
            var result = await _databaseContext.HomeCarePackage.FirstOrDefaultAsync(item => item.Id == homeCarePackageId).ConfigureAwait(false);
            return result;
        }

        public async Task<IList<HomeCarePackage>> ListAsync()
        {
            return await _databaseContext.HomeCarePackage.ToListAsync().ConfigureAwait(false);
        }

        public async Task<HomeCarePackage> ChangeStatusAsync(HomeCarePackage homeCarePackage)
        {
            HomeCarePackage homeCarePackageToUpdate = await _databaseContext.HomeCarePackage.FirstOrDefaultAsync(item => item.Id == homeCarePackage.Id).ConfigureAwait(false);
            if (homeCarePackageToUpdate != null)
            {
                homeCarePackageToUpdate.StatusId = homeCarePackage.StatusId;
                homeCarePackageToUpdate.Status = await _databaseContext.Status.FirstOrDefaultAsync(item => item.Id == homeCarePackage.StatusId).ConfigureAwait(false);
                homeCarePackageToUpdate.CreatorId = homeCarePackage.CreatorId;
                homeCarePackageToUpdate.UpdatorId = homeCarePackage.UpdatorId;
                homeCarePackageToUpdate.DateUpdated = DateTime.Now;
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return homeCarePackageToUpdate;
        }

        public async Task<HomeCarePackage> UpsertAsync(HomeCarePackage homeCarePackage)
        {
            HomeCarePackage homeCarePackageToUpdate = await _databaseContext.HomeCarePackage.
                FirstOrDefaultAsync(item => item.Id == homeCarePackage.Id).ConfigureAwait(false);
            if (homeCarePackageToUpdate == null)
            {
                homeCarePackageToUpdate = new HomeCarePackage();
                homeCarePackageToUpdate.StartDate = homeCarePackage.StartDate;
                homeCarePackageToUpdate.EndDate = homeCarePackage.EndDate;
                homeCarePackageToUpdate.IsFixedPeriod = homeCarePackage.IsFixedPeriod;
                homeCarePackageToUpdate.IsOngoingPeriod = homeCarePackage.IsOngoingPeriod;
                homeCarePackageToUpdate.IsThisAnImmediateService = homeCarePackage.IsThisAnImmediateService;
                homeCarePackageToUpdate.IsThisuserUnderS117 = homeCarePackage.IsThisuserUnderS117;
                await _databaseContext.HomeCarePackage.AddAsync(homeCarePackageToUpdate).ConfigureAwait(false);
            }
            homeCarePackageToUpdate.ClientId = homeCarePackage.ClientId;
            homeCarePackageToUpdate.Clients = await _databaseContext.Clients.FirstOrDefaultAsync(item => item.Id == homeCarePackage.ClientId).ConfigureAwait(false);
            homeCarePackageToUpdate.CreatorId = homeCarePackage.CreatorId;
            homeCarePackageToUpdate.DateCreated = homeCarePackage.DateCreated;
            homeCarePackageToUpdate.UpdatorId = homeCarePackage.UpdatorId;
            homeCarePackageToUpdate.DateUpdated = homeCarePackage.DateUpdated;
            homeCarePackageToUpdate.StatusId = homeCarePackage.StatusId;
            homeCarePackageToUpdate.Status = await _databaseContext.Status.FirstOrDefaultAsync(item => item.Id == homeCarePackageToUpdate.StatusId).ConfigureAwait(false);
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess ? homeCarePackageToUpdate : null;
        }
    }
}
